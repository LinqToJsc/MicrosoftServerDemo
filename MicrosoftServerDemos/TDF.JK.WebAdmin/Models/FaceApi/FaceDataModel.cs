using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDF.JK.WebAdmin.Models.FaceApi
{
    public class FaceDataModel
    {

        public Guid faceId { get; set; }

        public DaceRectangleData faceRectangle { get; set; }

        public FaceAttributesData faceAttributes { get; set; }

        //public FaceLandmarksData faceLandmarks { get; set; }

    }

    public class FaceApiErrorModel
    {
        public FaceErrorData error { get; set; }
    }

    public class FaceErrorData
    {
        public string code { get; set; }

        public int statusCode { get; set; }

        public string message { get; set; }

    }

    public class DaceRectangleData
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class FaceAttributesData
    {
        public double age { get; set; }

        public string gender { get; set; }
    }

    public class FaceLandmarksData
    {
        public XyData pupilLeft { get; set; }
        public XyData pupilRight { get; set; }
        public XyData noseTip { get; set; }
        public XyData mouthLeft { get; set; }
        public XyData mouthRight { get; set; }
        public XyData eyebrowLeftOuter { get; set; }
        public XyData eyebrowLeftInner { get; set; }
        public XyData eyeLeftOuter { get; set; }
        public XyData eyeLeftTop { get; set; }
        public XyData eyeLeftBottom { get; set; }
        public XyData eyeLeftInner { get; set; }
        public XyData eyebrowRightInner { get; set; }
        public XyData eyebrowRightOuter { get; set; }
        public XyData eyeRightInner { get; set; }
        public XyData eyeRightTop { get; set; }
        public XyData eyeRightBottom { get; set; }
        public XyData eyeRightOuter { get; set; }
        public XyData noseRootLeft { get; set; }
        public XyData noseRootRight { get; set; }
        public XyData noseLeftAlarTop { get; set; }
        public XyData noseRightAlarTop { get; set; }
        public XyData noseLeftAlarOutTip { get; set; }
        public XyData noseRightAlarOutTip { get; set; }
        public XyData upperLipTop { get; set; }
        public XyData upperLipBottom { get; set; }
        public XyData underLipTop { get; set; }
        public XyData underLipBottom { get; set; }
    }

    public class XyData
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}