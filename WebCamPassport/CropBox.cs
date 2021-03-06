﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace WebCamPassport
{
    public class CropBox
    {
        private PictureBox mPictureBox;
        public static Rectangle rect;
        public bool allowDeformingDuringMovement = false;
        private bool mIsClick = false;
        private bool mMove = false;
        private static int oldX;
        private static int oldY;
        private int sizeNodeRect = 10;
        private Bitmap mBmp = null;
        private PosSizableRect nodeSelected = PosSizableRect.None;
        public static float ratio = 1.33f;
        public static bool ratioEnabled;
        public static Bitmap croppedbmp;
        public static PictureBox pictureBox1 = new PictureBox();
        public static PictureBox snapShot = new PictureBox();
        
        private enum PosSizableRect
        {
            LeftBottom,
            LeftUp,
            RightUp,
            RightBottom,
            None

        }

       
        public CropBox(Rectangle r)
        {
            rect = r;
            mIsClick = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), rect);

            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
            }
        }

        public void SetBitmapFile(string filename)
        {
            this.mBmp = new Bitmap(filename);
        }

        public void SetBitmap(Bitmap bmp)
        {
            this.mBmp = bmp;
        }

        public void SetPictureBox(PictureBox p)
        {
            this.mPictureBox = p;
            mPictureBox.MouseDown += new MouseEventHandler(mPictureBox_MouseDown);
            mPictureBox.MouseUp += new MouseEventHandler(mPictureBox_MouseUp);
            mPictureBox.MouseMove += new MouseEventHandler(mPictureBox_MouseMove);
            mPictureBox.Paint += new PaintEventHandler(mPictureBox_Paint);
        }

        private void mPictureBox_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                Draw(e.Graphics);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }

        }

        private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mIsClick = true;

            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);

            if (rect.Contains(new Point(e.X, e.Y)))
            {
                mMove = true;
            }
            oldX = e.X;
            oldY = e.Y;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //Main snap = new Main();
            mIsClick = false;
            mMove = false;
            mPictureBox.Invalidate();
            //TakePic(pictureBox1, snapShot);
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeCursor(e.Location);
            if (mIsClick == false)
            {
                return;
            }

            Rectangle backupRect = rect;

            switch (nodeSelected)
            {
                case PosSizableRect.LeftUp:
                    mPictureBox.Cursor = Cursors.SizeNWSE;
                    rect.X = e.X;
                    rect.Y = e.Y;
                    rect.Width = backupRect.Right - e.X;
                    rect.Height = backupRect.Bottom - e.Y;
                    if(ratioEnabled == true)
                    {
                        if (rect.Width > rect.Height)
                        {
                            int newHeight = (int)(rect.Width * ratio);
                            rect.Y = rect.Bottom - newHeight;
                            rect.Height = newHeight;
                        }
                        else
                        {
                            int newWidth = (int)(rect.Height / ratio);
                            rect.X = rect.Right - newWidth;
                            rect.Width = newWidth;

                        }
                    }
                    break;
                case PosSizableRect.LeftBottom:
                    mPictureBox.Cursor = Cursors.SizeNESW;
                    rect.X = e.X;
                    rect.Y = backupRect.Y;
                    rect.Width = backupRect.Right - e.X;
                    rect.Height = e.Y - rect.Top;
                    if (ratioEnabled == true)
                    {
                        if (rect.Width > rect.Height)
                        {
                            rect.Height = (int)(rect.Width * ratio);
                        }
                        else
                        {
                            int newWidth = (int)(rect.Height / ratio);
                            rect.X = rect.Right - newWidth;
                            rect.Width = newWidth;
                        }
                    }
                    break;
                case PosSizableRect.RightUp:
                    mPictureBox.Cursor = Cursors.SizeNESW;
                    rect.X = backupRect.X;
                    rect.Y = e.Y;
                    rect.Width = e.X - rect.Left;
                    rect.Height = backupRect.Bottom - e.Y;
                    if (ratioEnabled == true)
                    {
                        if (rect.Width > rect.Height)
                        {
                            int newHeight = (int)(rect.Width * ratio);
                            rect.Y = rect.Bottom - newHeight;
                            rect.Height = newHeight;
                        }
                        else
                        {
                            int newWidth = (int)(rect.Height / ratio);
                            rect.Width = newWidth;
                        }
                    }
                    break;
                case PosSizableRect.RightBottom:
                    mPictureBox.Cursor = Cursors.SizeNWSE;
                    rect.Width += e.X - oldX;
                    rect.Height += e.Y - oldY;
                    if (ratioEnabled == true)
                    {
                        if (rect.Width > rect.Height)
                        {
                            rect.Height = (int)(rect.Width * ratio);
                        }
                        else
                        {
                            rect.Width = (int)(rect.Height / ratio);
                        }
                    }
                    break;

                default:
                    if (mMove)
                    {
                        rect.X = rect.X + e.X - oldX;
                        rect.Y = rect.Y + e.Y - oldY;
                    }
                    break;
            }
            oldX = e.X;
            oldY = e.Y;


            if (rect.Width < 5 || rect.Height < 5)
            {
                rect = backupRect;
            }
            

          //  TestIfRectInsideArea();
            mPictureBox.Invalidate();
        }
              
        private void TestIfRectInsideArea()
        {
            // Test if rectangle still inside the area.
            if (rect.X < 0) rect.X = 0;
            if (rect.Y < 0) rect.Y = 0;
            if (rect.Width <= 0) rect.Width = 1;
            if (rect.Height <= 0) rect.Height = 1;

            if (rect.X + rect.Width > mPictureBox.Width)
            {
                rect.Width = mPictureBox.Width - rect.X - 1; // -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
            if (rect.Y + rect.Height > mPictureBox.Height)
            {
                rect.Height = mPictureBox.Height - rect.Y - 1;// -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
        }

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }

        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(rect.X, rect.Y);

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(rect.X, rect.Y + rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y);

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height);

                default:
                    return new Rectangle();
            }
        }

        private PosSizableRect GetNodeSelectable(Point p)
        {
            foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;
                }
            }
            return PosSizableRect.None;
        }

        private void ChangeCursor(Point p)
        {
            mPictureBox.Cursor = GetCursor(GetNodeSelectable(p));
        }

        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return Cursors.SizeNWSE;

                case PosSizableRect.LeftBottom:
                    return Cursors.SizeNESW;

                case PosSizableRect.RightUp:
                    return Cursors.SizeNESW;

                case PosSizableRect.RightBottom:
                    return Cursors.SizeNWSE;

                default:
                    return Cursors.Default;
            }
        }

        public static void TakePic(PictureBox c, PictureBox s)
        {
            
            pictureBox1 = c;
            snapShot = s;

            Point p = rect.Location;
            Point unscaled_p = new Point();
            int unscaled_height = new int();
            int unscaled_width = new int();

            int w_i = new int();
            int h_i = new int();
            int w_c = new int();
            int h_c = new int();

            // image and container dimensions
            w_i = pictureBox1.Image.Width;
            h_i = pictureBox1.Image.Height;
            w_c = pictureBox1.Width;
            h_c = pictureBox1.Height;

            float imageRatio = w_i / (float)h_i; // image W:H ratio
            float containerRatio = w_c / (float)h_c; // container W:H ratio

            if (imageRatio >= containerRatio)
            {
                // horizontal image
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                // calculate gap between top of container and top of image
                float filler = Math.Abs(h_c - scaledHeight) / 2;
                unscaled_p.X = (int)(p.X / scaleFactor);
                unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
                unscaled_width = (int)(rect.Width / scaleFactor);
                unscaled_height = (int)(rect.Height / scaleFactor);
            }
            else
            {
                // vertical image
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
                unscaled_p.X = (int)((p.X - filler) / scaleFactor);
                unscaled_p.Y = (int)(p.Y / scaleFactor);
                unscaled_width = (int)(rect.Width / scaleFactor);
                unscaled_height = (int)(rect.Height / scaleFactor);
            }


            Rectangle cropBoxUnscaled = new Rectangle(unscaled_p.X, unscaled_p.Y, unscaled_width, unscaled_height);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            croppedbmp = bmp.Clone(cropBoxUnscaled, bmp.PixelFormat);
            snapShot.Image = croppedbmp;
            snapShot.Invalidate();
        }

    }

}
