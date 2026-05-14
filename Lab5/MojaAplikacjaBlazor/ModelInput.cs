//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using Microsoft.ML.Data;

namespace MLModel.Model
{
    public class ModelInput
    {
        [ColumnName("textID"), LoadColumn(0)]
        public string TextID { get; set; }


        [ColumnName("text"), LoadColumn(1)]
        public string Text { get; set; }


        [ColumnName("selected_text"), LoadColumn(2)]
        public string Selected_text { get; set; }


        [ColumnName("sentiment"), LoadColumn(3)]
        public string Sentiment { get; set; }


        [ColumnName("Time of Tweet"), LoadColumn(4)]
        public string Time_of_Tweet { get; set; }


        [ColumnName("Age of User"), LoadColumn(5)]
        public string Age_of_User { get; set; }


        [ColumnName("Country"), LoadColumn(6)]
        public string Country { get; set; }


        [ColumnName("Population -2020"), LoadColumn(7)]
        public float Population__2020 { get; set; }


        [ColumnName("Land Area (Km�)"), LoadColumn(8)]
        public float Land_Area__Km__ { get; set; }


        [ColumnName("Density (P/Km�)"), LoadColumn(9)]
        public float Density__P_Km__ { get; set; }


    }
}
