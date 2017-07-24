using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Windows.Forms;
using System.Diagnostics;

//==================================================================================================================================
//this project is built to get everday's values of fund of nomurafunds funds .com.tw, in order get further investigation
//==================================================================================================================================
//note: http://www.nomurafunds.com.tw/aries/fund/fundNav_Shore.aspx?FundGroupID=6E683F1A-2505-4D0D-9675-448967772A54 is 野村e科技  [野村e科技基金]
//note: http://www.nomurafunds.com.tw/aries/fund/fundNav_Shore.aspx?FundGroupID=F6FC1004-FC44-4BBD-A4F5-3A9F217226B4 is 野村全球品牌  [野村全球品牌基金]
//note: http://www.nomurafunds.com.tw/aries/fund/fundNav_Shore.aspx?FundGroupID=6F7DFABA-D4CA-46C7-84B0-BA70AB65D3B4 is 野村泰國  [野村泰國基金]

namespace fundValsGetter
{
	public partial class frmMain : Form
	{
		public int curCursorX = 393;
		public Bitmap theDataImg = null;
        public List<string> vals = new List<string>();

		public frmMain()
		{
			InitializeComponent();
		}

		private void IE_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{

		}

		private void btnGet_Click(object sender, EventArgs e)
		{
			
			getNextData();
		}

		private void getNextData()
		{
            //move to starting point
            curCursorX = 393;
            txtResult.Text = "";
            this.Cursor = new Cursor(Cursor.Current.Handle);
			Cursor.Position = new Point(curCursorX, 750);
            vals.Clear();
            watch.Enabled = true;
			watch.Start();
            btnStop.Focus();
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			IE.Navigate(@"http://www.nomurafunds.com.tw/aries/fund/fundNav_Shore.aspx?FundGroupID=6F7DFABA-D4CA-46C7-84B0-BA70AB65D3B4");
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Location = new Point(0, 0);
		}

		private void btnDebug_Click(object sender, EventArgs e)
		{
            //Rectangle rect = new Rectangle(0, 0, 145, 8);
            //Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            //Graphics g = Graphics.FromImage(bmp);
            //g.CopyFromScreen(834, 630, 834 + 145, 630 + 8, bmp.Size, CopyPixelOperation.SourceCopy);
            //bmp.Save(@"D:\123.jpg", ImageFormat.Jpeg);

            //Bitmap bmp = CaptureScreen();
            //bmp.Save(@"D:\456.jpg");
            //MessageBox.Show(bmp.Width.ToString() + "X" + bmp.Height.ToString());

            //ResourceManager rm = fundValsGetter.Properties.Resources.ResourceManager;
            //Bitmap myImage = (Bitmap)rm.GetObject("ds");
            //MessageBox.Show(myImage.Height.ToString());

            /*
			Bitmap src = new Bitmap(@"D:\capture5.bmp");
			Bitmap bmp = new Bitmap(3, 8, PixelFormat.Format32bppArgb);

			int srcoffset = 122;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j<8; j++)
				{
					X = src.GetPixel(i + srcoffset, j);
					if (X.R > 250 && X.G > 100 && X.G < 200 && X.B < 200) bmp.SetPixel(i, j, Color.Black); else bmp.SetPixel(i, j, Color.White); 
				}
			}

			bmp.Save(@"D:\d.jpg");
			*/

			Bitmap src = new Bitmap(@"D:\Untitled.bmp");
			/*
			Bitmap bmp = new Bitmap(140, 8);
			Color X = new Color();
			for (int i = 0; i < src.Width; i++)
			{
				for (int j = 0; j < src.Height; j++)
				{
					X = src.GetPixel(i, j);
					if (X.R > 250 && X.G > 100 && X.G < 200 && X.B < 200) X = Color.Black; else X = Color.White;
					bmp.SetPixel(i, j, X);
				}
			}
			bmp.Save(@"D:\capturey.jpg");
			 * */
            string x = getBMPString(src);
        }

		//to get the string that a bitmap represents
		private string getBMPString(Bitmap gotBMP)
		{
			//current X position of the gotBMP, get from the screenshot
			int curXPos = 0;
			// for storing the compare result
			string data = "";
			//a string for return back;
			string ret = "";
			bool gotADigit = false;
			bool gotTheDot = false;
			while (curXPos < gotBMP.Width)
			{
				gotADigit = false;
				for (int i = 0; i < 10; i++)
				{
					//see if get a matched digit 
					data = oneDigitComp(gotBMP, curXPos, "d" + i.ToString());
					if (data == "d" + i.ToString())
					{
						ret = ret + i.ToString();
						curXPos = curXPos + 5;
						gotADigit = true;
						break;
					}
				}
				//doesn't get any matched digit, but might be either a slash(/) or dot(.)
				if (!gotADigit && !gotTheDot && (curXPos > 110))
				{
					data = oneDigitComp(gotBMP, curXPos, "dd");
					ret = ret + ".";
					curXPos = curXPos + 2;
					gotTheDot = true;
				}
				curXPos = curXPos + 1;
				if (ret.Length == 8) curXPos = 110;
			}
			return refineData(ret);
		}

		string refineData(string income)
		{
			//first 8 digits reprents date, and the rest are its value
			string ret = income.Substring(0, 8);
			string valStr = income.Substring(8);
			if (valStr.Substring(valStr.Length - 1, 1) == ".") valStr = valStr + "00";
			if (valStr.Substring(valStr.Length - 2, 1) == ".") valStr = valStr + "0";
			return ret + "," + valStr;
		}

		//to compare if it fits that digit
		//p1: the gotten image in bitmap
		//p2: X position, where to start comparing
		//p3: resource name of image in project
		private string oneDigitComp(Bitmap gotBMP, int posX, string rsName)
		{
            int tolerance = 1;
			//rm for resource manager of the application
			ResourceManager rm = fundValsGetter.Properties.Resources.ResourceManager;
			//get the template jpg from resources 
			Bitmap compBMP = (Bitmap)rm.GetObject(rsName);
			if (posX + compBMP.Width > gotBMP.Width) return "";
			string ret = "";
			Color X = new Color();
			Color Y = new Color();
			for (int i = 0; i < compBMP.Width; i++)
			{
				for (int j = 0; j < compBMP.Height; j++)
				{
					X = gotBMP.GetPixel(i + posX, j);
                    if (X.R > 250 && X.G > 100 && X.G < 200 && X.B < 200) X = Color.Black; else X = Color.White;
                    Y = compBMP.GetPixel(i, j);
                    if ((X.G != Y.G) || (X.R != Y.R) || (X.B != Y.B)) tolerance--;
                    if (tolerance < 0) break;
				}
                if (tolerance < 0) break;
            }
            if (tolerance >= 0) ret = rsName;
			return ret;
		}

		private int colorDiff(Color X, Color Y)
		{
			int ret = 0;
			ret = ret + Math.Abs(Convert.ToInt16(X.R) - Convert.ToInt16(Y.R));
			ret = ret + Math.Abs(Convert.ToInt16(X.G) - Convert.ToInt16(Y.G));
			ret = ret + Math.Abs(Convert.ToInt16(X.B) - Convert.ToInt16(Y.B));
			return ret;
		}

		//capture a certain region of screen to bitmap
		private Bitmap CaptureScreen()
		{
			Bitmap bmp = new Bitmap(145, 8);
			Graphics g = Graphics.FromImage(bmp);
			if (Environment.MachineName == "CENTAPC" || Environment.MachineName == "PACKAGER-PC") g.CopyFromScreen(835, 630, 0, 0, new Size(145, 8)); else g.CopyFromScreen(835, 665, 0, 0, new Size(145, 8));
			return bmp;
		}

		private void watch_Tick(object sender, EventArgs e)
		{
			Debug.WriteLine("tick");			
			theDataImg = CaptureScreen();
			theDataImg.Save(@"D:\capturex.jpg");
			watch.Stop();
            string data = getBMPString(theDataImg);
            if (!vals.Contains(data)) {
                vals.Add(data);
                txtResult.Text = txtResult.Text + getBMPString(theDataImg) + "\n";
            }
			curCursorX++;
			this.Cursor = new Cursor(Cursor.Current.Handle);
			Cursor.Position = new Point(curCursorX, 750);
			if (curCursorX < 980) watch.Start();
		}

        private void btnStop_Click(object sender, EventArgs e)
        {
            watch.Enabled = false;
        }
    }
}
