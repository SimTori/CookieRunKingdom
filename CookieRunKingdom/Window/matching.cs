using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRunKingdom
{
    public partial class MainWindow
    {
        public void imgMatchingTest()
        {
            string fileName = "1";
            string path = "img\\";
            int width = 1284;
            int height = 754;

            ImaData imaData = new ImaData(fileName, path, 0, 0, width, height, 0.99f);

            if (ImageMatching(imaData))
            {
                Debug.Print("asdfasdf");
            }

        }

        public bool ImageMatching(ImaData imaData, bool isClick = false, float allow = 0.0f)
        {

            //파일이미지꺼내오기
            int x = imaData.pos.loc1;
            int y = imaData.pos.loc2;
            int w = imaData.pos.loc3 - imaData.pos.loc1;
            int h = imaData.pos.loc4 - imaData.pos.loc2;
            Image<Bgr, byte> targetImage = imaData.Image;
            if (allow == 0.0f)
            {
                allow = imaData.allow;
            }

            //캡쳐자르기
            windowCaptureImage.ROI = new Rectangle(x, y, w, h);

            //비교후 결과
            Image<Gray, float> resultImage = windowCaptureImage.MatchTemplate(targetImage, TemplateMatchingType.CcorrNormed);

            //결과값꺼내오기
            double[] minValues = null;
            double[] maxValues = null;
            System.Drawing.Point[] minLocations = null;
            System.Drawing.Point[] maxLocations = null;
            resultImage.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
            resultImage.Dispose();
            Debug.Print("비교 > " + imaData.fileName + " [ " + maxValues[0].ToString("0.000") + " ]");
            if (maxValues[0] >= allow)
            {
                if (isClick == true)
                {
                    //찾은 이미지의 중앙지점
                    int clickX = x + maxLocations[0].X + (int)(targetImage.Size.Width * 0.5f);
                    int clickY = y + maxLocations[0].Y + (int)(targetImage.Size.Height * 0.5f);

                }
                Debug.Print("발견");
                return true;
            }
            Debug.Print("미발견");
            return false;
        }
    }

    
}
