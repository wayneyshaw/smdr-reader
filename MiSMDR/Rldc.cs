//Mitel SMDR Reader
//Copyright (C) 2013 Insight4 Pty. Ltd. and Nicholas Evan Roberts

//This program is free software; you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation; either version 2 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License along
//with this program; if not, write to the Free Software Foundation, Inc.,
//51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
using System;
using System.Data;
using System.Globalization;
using System.Xml;
using System.Drawing;

namespace MiSMDR
{
    /// <summary>
    /// This class builds a dynamic RDL based on parameter settings, a dataset, and a string array of column header overrides.
    /// It will save the RDL to the location of the exe.
    /// Then the RDL's components may be picked out to be used with a ReportViewer control to show the data in the dataset using the RDL definition as a template
    /// </summary>
    public class Rdlc : IDisposable
    {
        #region Private Members
        private Color _backgroundColorHeader = Color.FromArgb(238, 238, 238); //gray
        private Color _textColorHeader = Color.FromArgb(0, 0, 0);
        private int _fontWeightHeader = 100;
        private FontStyle _fontStyleHeader = FontStyle.Regular;
        private FontFamily _fontFamilyHeader = new FontFamily("Arial");
        private string _fontSizeHeader = "8pt";
        private string _textAlignHeader = "Left";

        private Color _backgroundColorBody = Color.FromArgb(255, 255, 255);
        private Color _textColorHeaderBody = Color.FromArgb(0, 0, 0);
        private int _fontWeightBody = 100;
        private FontStyle _fontStyleBody = FontStyle.Regular;
        private FontFamily _fontFamilyBody = new FontFamily("Arial");
        private string _fontSizeBody = "8pt";
        private string _textAlignBody = "Left";

        private Color _backgroundColorAltBody = Color.FromArgb(238, 238, 238); //gray
        private Color _textColorHeaderAltBody = Color.FromArgb(0, 0, 0);

        private Color _backgroundColorFooter = Color.FromArgb(255, 255, 255);
        private Color _textColorHeaderFooter = Color.FromArgb(0, 0, 0);
        private int _fontWeightFooter = 100;
        private FontStyle _fontStyleFooter = FontStyle.Regular;
        private FontFamily _fontFamilyFooter = new FontFamily("Arial");
        private string _fontSizeFooter = "8pt";
        private string _textAlignFooter = "Left";

        private DataSet _data = new DataSet("Default");

        private string _reportPath = @"C:\Reports\";
        private string _reportName = "Default.rdlc";

        private string[] _headers = null;

        private bool disposed;

        #endregion

        #region Public Properties

        /// <summary>
        /// The background color for the report header
        /// </summary>
        public Color BackgroundColorHeader
        {
            get
            {
                return _backgroundColorHeader;
            }
            set
            {
                Color _temp = value;

                _backgroundColorHeader = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the text color of the header
        /// </summary>
        public Color TextColorHeader
        {
            get
            {
                return _textColorHeader;
            }
            set
            {
                Color _temp = value;

                _textColorHeader = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the font weight of hte header
        /// </summary>
        public int FontWeightHeader
        {
            get
            {
                return _fontWeightHeader;
            }
            set
            {
                _fontWeightHeader = value;
            }
        }

        /// <summary>
        /// the font style of the header
        /// </summary>
        public FontStyle FontStyleHeader
        {
            get
            {
                return _fontStyleHeader;
            }
            set
            {
                _fontStyleHeader = value;
            }
        }

        //the font family of the header
        public FontFamily FontFamilyHeader
        {
            get
            {
                return _fontFamilyHeader;
            }
            set
            {
                _fontFamilyHeader = value;
            }
        }

        /// <summary>
        /// the font size of the header
        /// </summary>
        public string FontSizeHeader
        {
            get
            {
                return _fontSizeHeader;
            }
            set
            {
                _fontSizeHeader = value;
            }
        }

        /// <summary>
        /// the background color of the body
        /// </summary>
        public Color BackgroundColorBody
        {
            get
            {
                return _backgroundColorBody;
            }
            set
            {
                Color _temp = value;

                _backgroundColorBody = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the text color of the body
        /// </summary>
        public Color TextColorBody
        {
            get
            {
                return _textColorHeaderBody;
            }
            set
            {
                Color _temp = value;

                _textColorHeaderBody = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the font weight of the body
        /// </summary>
        public int FontWeightBody
        {
            get
            {
                return _fontWeightBody;
            }
            set
            {
                _fontWeightBody = value;
            }
        }

        /// <summary>
        /// the font style of the body
        /// </summary>
        public FontStyle FontStyleBody
        {
            get
            {
                return _fontStyleBody;
            }
            set
            {
                _fontStyleBody = value;
            }
        }

        /// <summary>
        /// the font family of the body
        /// </summary>
        public FontFamily FontFamilyBody
        {
            get
            {
                return _fontFamilyBody;
            }
            set
            {
                _fontFamilyBody = value;
            }
        }

        /// <summary>
        /// the font size of the body
        /// </summary>
        public string FontSizeBody
        {
            get
            {
                return _fontSizeBody;
            }
            set
            {
                _fontSizeBody = value;
            }
        }

        /// <summary>
        /// the background color of the footer
        /// </summary>
        public Color BackgroundColorFooter
        {
            get
            {
                return _backgroundColorFooter;
            }
            set
            {
                Color _temp = value;

                _backgroundColorFooter = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the text color of the footer
        /// </summary>
        public Color TextColorFooter
        {
            get
            {
                return _textColorHeaderFooter;
            }
            set
            {
                Color _temp = value;

                _textColorHeaderFooter = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the font weight of the footer
        /// </summary>
        public int FontWeightFooter
        {
            get
            {
                return _fontWeightFooter;
            }
            set
            {
                _fontWeightFooter = value;
            }
        }

        /// <summary>
        /// the font style of the footer
        /// </summary>
        public FontStyle FontStyleFooter
        {
            get
            {
                return _fontStyleFooter;
            }
            set
            {
                _fontStyleFooter = value;
            }
        }

        /// <summary>
        /// the font family of the footer
        /// </summary>
        public FontFamily FontFamilyFooter
        {
            get
            {
                return _fontFamilyFooter;
            }
            set
            {
                _fontFamilyFooter = value;
            }
        }

        /// <summary>
        /// the font size of the footer
        /// </summary>
        public string FontSizeFooter
        {
            get
            {
                return _fontSizeFooter;
            }
            set
            {
                _fontSizeFooter = value;
            }
        }

        /// <summary>
        /// the name of the report.  This is also used for the file name.
        /// </summary>
        public string ReportName
        {
            get
            {
                return _reportName;
            }
            set
            {
                _reportName = value;
            }
        }

        /// <summary>
        /// the path of the report file. The default location for the .rdlc is %executingassemblypath%\Reports\
        /// </summary>
        public string ReportPath
        {
            get
            {
                return _reportPath;
            }
            set
            {
                _reportPath = value;
            }
        }

        /// <summary>
        /// The Data for the report
        /// </summary>
        public DataSet Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// The text alignment for the header
        /// </summary>
        public string TextAlignHeader
        {
            get
            {
                return _textAlignHeader;
            }
            set
            {
                _textAlignHeader = value;
            }
        }

        /// <summary>
        /// the text alignment for the body
        /// </summary>
        public string TextAlignBody
        {
            get
            {
                return _textAlignBody;
            }
            set
            {
                _textAlignBody = value;
            }
        }

        /// <summary>
        /// the text alignment for the footer
        /// </summary>
        public string TextAlignFooter
        {
            get
            {
                return _textAlignFooter;
            }
            set
            {
                _textAlignFooter = value;
            }
        }

        /// <summary>
        /// the background color for alternating rows in the body
        /// </summary>
        public Color BackgroundColorBodyAlternate
        {
            get
            {
                return _backgroundColorAltBody;
            }
            set
            {
                Color _temp = value;

                _backgroundColorAltBody = Color.FromArgb(_temp.ToArgb());
            }
        }

        /// <summary>
        /// the text color for alternating rows in the body
        /// </summary>
        public Color TextColorBodyAlternate
        {
            get
            {
                return _textColorHeaderAltBody;
            }
            set
            {
                Color _temp = value;

                _textColorHeaderAltBody = Color.FromArgb(_temp.ToArgb());
            }
        }
        #endregion

        #region Constructors
        public Rdlc(DataSet dataSet)
            : this(dataSet, null)
        {
            //do nothing, let the other constructor handle the set up
        }

        public Rdlc(DataSet dataSet, params string[] headers)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet", "dataSet cannot be null.");
            }

            _data = dataSet;

            _data.Locale = System.Globalization.CultureInfo.InvariantCulture;

            if (headers == null)
            {
                _headers = new string[0];
            }
            else
            {
                _headers = headers;
            }
        }

        #endregion

        #region RDLC Generation

        /// <summary>
        /// generate the RDLC using the settings.  The default location for the .rdlc is %executingassemblypath%\Reports\
        /// </summary>
        public void GenerateRdlcFile()
        {
            #region ReportPath Generation
            string _path = System.AppDomain.CurrentDomain.BaseDirectory;
            _path = _path.Substring(0, _path.LastIndexOf("\\"));

            string _dirPath = _path + @"\Reports\";

            if (!System.IO.Directory.Exists(_dirPath))
            {
                System.IO.Directory.CreateDirectory(_dirPath);
            }

            ReportPath = _dirPath + _data.DataSetName + ".rdlc";
            #endregion

            XmlTextWriter _rdl = new XmlTextWriter(ReportPath, null);

            DataTable data = _data.Tables[0];

            _rdl.Formatting = Formatting.Indented;
            _rdl.Indentation = 3;
            _rdl.Namespaces = true;

            int _columns = data.Columns.Count;

            try
            {
                _rdl.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"utf-8\"");

                //Report

                _rdl.WriteStartElement("", "Report", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
                //_rdl.WriteAttributeString("xmlns:rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");

                #region RDL Header Section (settings)

                _rdl.WriteStartElement("", "BottomMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "RightMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "InteractiveWidth", null);
                _rdl.WriteString("8.5in");
                _rdl.WriteEndElement();

                #endregion

                #region Data Set

                // DataSource element
                _rdl.WriteStartElement("DataSources");
                _rdl.WriteStartElement("DataSource");
                _rdl.WriteAttributeString("Name", null, data.DataSet.DataSetName);
                _rdl.WriteStartElement("ConnectionProperties");
                _rdl.WriteElementString("DataProvider", "Oracle");
                _rdl.WriteElementString("ConnectString", "ItsaSecret");
                _rdl.WriteElementString("IntegratedSecurity", "true");
                _rdl.WriteEndElement(); // ConnectionProperties
                _rdl.WriteEndElement(); // DataSource
                _rdl.WriteEndElement(); // DataSources

                // DataSet element
                _rdl.WriteStartElement("DataSets");
                _rdl.WriteStartElement("DataSet");
                _rdl.WriteAttributeString("Name", null, data.DataSet.DataSetName);

                // Query element
                _rdl.WriteStartElement("Query");
                _rdl.WriteElementString("DataSourceName", data.DataSet.DataSetName);
                _rdl.WriteElementString("CommandType", "Text");
                _rdl.WriteElementString("CommandText", "wouldntyouliketoknow");
                _rdl.WriteElementString("Timeout", "30");
                _rdl.WriteEndElement(); // Query

                // Fields elements
                _rdl.WriteStartElement("Fields");

                for (int x = 0; x < _columns; x++)
                {
                    _rdl.WriteStartElement("Field");
                    _rdl.WriteAttributeString("Name", null, data.Columns[x].ColumnName);
                    _rdl.WriteElementString("DataField", null, data.Columns[x].ColumnName);
                    _rdl.WriteEndElement(); // Field
                }

                // End previous elements
                _rdl.WriteEndElement(); // Fields
                _rdl.WriteEndElement(); // DataSet
                _rdl.WriteEndElement(); // DataSets


                #endregion

                _rdl.WriteStartElement("", "Body", null);

                _rdl.WriteStartElement("", "ReportItems", null);

                #region Header Text
                _rdl.WriteStartElement("", "Textbox", null);
                _rdl.WriteAttributeString("Name", "textbox1");

                _rdl.WriteStartElement("", "Style", null);
                _rdl.WriteStartElement("", "Color", null);
                _rdl.WriteString("ForestGreen");
                _rdl.WriteEndElement(); // Color
                _rdl.WriteStartElement("", "FontFamily", null);
                _rdl.WriteString("Arial");
                _rdl.WriteEndElement(); // FontFamily
                _rdl.WriteStartElement("", "FontSize", null);
                _rdl.WriteString("20pt");
                _rdl.WriteEndElement(); // FontSize
                _rdl.WriteStartElement("", "FontWeight", null);
                _rdl.WriteString("700");
                _rdl.WriteEndElement(); // FontWeight
                _rdl.WriteStartElement("", "PaddingLeft", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingLeft
                _rdl.WriteStartElement("", "PaddingRight", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingRight
                _rdl.WriteStartElement("", "PaddingTop", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingTop
                _rdl.WriteStartElement("", "PaddingBottom", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingBottom
                _rdl.WriteEndElement(); // Style

                _rdl.WriteStartElement("", "ZIndex", null);
                _rdl.WriteString("1");
                _rdl.WriteEndElement(); // ZIndex
                _rdl.WriteStartElement("", "CanGrow", null);
                _rdl.WriteString("true");
                _rdl.WriteEndElement(); // CanGrow
                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("1cm");
                _rdl.WriteEndElement(); // Height
                _rdl.WriteStartElement("", "Value", null);
                _rdl.WriteString("MiSMDR Call Summary");
                _rdl.WriteEndElement(); // Value

                _rdl.WriteEndElement(); //Textbox
                #endregion

                _rdl.WriteStartElement("", "Table", null);
                _rdl.WriteAttributeString("Name", "table1");

                #region Footer
                _rdl.WriteStartElement("", "Footer", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                int _footerIndex = _columns * 3;

                //write all the footer items
                for (int x = 0; x < _columns; x++)
                {
                    int _zindex = (_footerIndex + x);
                    string _name = "textbox" + _zindex;

                    string _bgColor = System.Drawing.ColorTranslator.ToHtml(BackgroundColorFooter);
                    string _textColor = System.Drawing.ColorTranslator.ToHtml(TextColorFooter);

                    AddCell(_rdl, _name, _bgColor, _textColor, TextAlignFooter, 0, _zindex, "");
                }

                #endregion

                //end TableCells
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();

                //end TableRow
                _rdl.WriteEndElement();

                //end TableRows
                _rdl.WriteEndElement();

                //end footer
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Top", null);
                _rdl.WriteString("0.625in");
                _rdl.WriteEndElement();

                #region Details

                _rdl.WriteStartElement("", "Details", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                int _detailIndex = _columns * 2;

                //write all the detail items
                for (int x = 0; x < _columns; x++)
                {
                    int _zindex = (_detailIndex + x);
                    string _name = "textbox" + _zindex;
                    string _value = "=Fields!" + data.Columns[x].ColumnName + ".Value";

                    //Alternate the colors by row
                    string _bgcolor = "=iif(RowNumber(Nothing) Mod 2, \"" + System.Drawing.ColorTranslator.ToHtml(BackgroundColorBody) + "\", \"" + System.Drawing.ColorTranslator.ToHtml(BackgroundColorBodyAlternate) + "\")";
                    string _textcolor = "=iif(RowNumber(Nothing) Mod 2, \"" + System.Drawing.ColorTranslator.ToHtml(TextColorBody) + "\", \"" + System.Drawing.ColorTranslator.ToHtml(TextColorBodyAlternate) + "\")";

                    AddCell(_rdl, _name, _bgcolor, _textcolor, TextAlignFooter, 0, _zindex, _value);
                }

                //end TableCells
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();

                //end TableRow
                _rdl.WriteEndElement();

                //end TableRows
                _rdl.WriteEndElement();

                //end detail
                _rdl.WriteEndElement();

                #endregion

                #region Header

                _rdl.WriteStartElement("", "Header", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                int _headerIndex = 1;

                //write all the header items
                for (int x = 0; x < _columns; x++)
                {
                    int _zindex = (_headerIndex + x);
                    string _name = "textbox" + _zindex;

                    string _value = data.Columns[x].ColumnName;

                    //Allow the user to override and use the default column name by passing in an empty string
                    if (x < _headers.Length && !string.IsNullOrEmpty(_headers[x]))
                    {
                        _value = _headers[x];
                    }

                    string _bgColor = System.Drawing.ColorTranslator.ToHtml(BackgroundColorHeader);
                    string _textColor = System.Drawing.ColorTranslator.ToHtml(TextColorHeader);

                    AddCell(_rdl, _name, _bgColor, _textColor, TextAlignFooter, 700, _zindex, _value);
                }

                //end TableCells
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();

                //end TableRow
                _rdl.WriteEndElement();

                //end TableRows
                _rdl.WriteEndElement();

                //end detail
                _rdl.WriteEndElement();

                #endregion

                #region Table Settings

                _rdl.WriteStartElement("", "TableColumns", null);

                for (int x = 0; x < _columns; x++)
                {
                    _rdl.WriteStartElement("", "TableColumn", null);
                    _rdl.WriteStartElement("", "Width", null);
                    _rdl.WriteString("2.16667in");
                    _rdl.WriteEndElement();

                    //end TableColumn
                    _rdl.WriteEndElement();
                }

                //end TableColumns
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.75in");
                _rdl.WriteEndElement();

                #endregion

                //end Table
                _rdl.WriteEndElement();

                //end ReportItems
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("2in");
                _rdl.WriteEndElement();

                //end Body
                _rdl.WriteEndElement();

                #region Document Footer Section (settings)

                _rdl.WriteStartElement("", "LeftMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Width", null);
                _rdl.WriteString("8.66667in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "InteractiveHeight", null);
                _rdl.WriteString("11in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Language", null);
                _rdl.WriteString("en-US");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "TopMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                #endregion

                //End of report
                _rdl.WriteEndElement();

                
                //write the document to file
                _rdl.Flush();
            }
            catch
            {
                throw;
            }
            finally
            {
                //close the document
                _rdl.Close();
            }
        }

        public System.IO.MemoryStream GetRdlcStream(int groupedColumn)
        {
            //string output = GetRdlcString(groupedColumn);
            string output = GetRDLC();

            byte[] rdlBytes = System.Text.Encoding.UTF8.GetBytes(output);
            
            return new System.IO.MemoryStream(rdlBytes);
        }

        public string GetRDLC()
        {
            return @"<?xml version='1.0' encoding='utf-8'?>
<Report xmlns='http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition' xmlns:rd='http://schemas.microsoft.com/SQLServer/reporting/reportdesigner'>
  <DataSources>
    <DataSource Name='CallData'>
      <rd:DataSourceID>b6767671-12cb-4453-b4c6-c531a19141ff</rd:DataSourceID>
      <ConnectionProperties>
        <DataProvider>Oracle</DataProvider>
        <ConnectString>ItsaSecret</ConnectString>
        <IntegratedSecurity>true</IntegratedSecurity>
      </ConnectionProperties>
    </DataSource>
  </DataSources>
  <InteractiveHeight>13in</InteractiveHeight>
  <rd:DrawGrid>true</rd:DrawGrid>
  <InteractiveWidth>7in</InteractiveWidth>
  <rd:SnapToGrid>true</rd:SnapToGrid>
  <RightMargin>0.5in</RightMargin>
  <LeftMargin>0.5in</LeftMargin>
  <BottomMargin>0.5in</BottomMargin>
  <rd:ReportID>11d963d5-48e5-4187-8fef-c62c2b6e72cb</rd:ReportID>
  <DataSets>
    <DataSet Name='CallData'>
      <Fields>
        <Field Name='Call_Date'>
          <DataField>Call_Date</DataField>
        </Field>
        <Field Name='Duration'>
          <DataField>Duration</DataField>
        </Field>
        <Field Name='Caller_Name'>
          <DataField>Caller_Name</DataField>
        </Field>
        <Field Name='Caller_Number'>
          <DataField>Caller_Number</DataField>
        </Field>
        <Field Name='Receiver_Name'>
          <DataField>Receiver_Name</DataField>
        </Field>
        <Field Name='Receiver_Number'>
          <DataField>Receiver_Number</DataField>
        </Field>
        <Field Name='Cost'>
          <DataField>Cost</DataField>
        </Field>
      </Fields>
      <Query>
        <DataSourceName>CallData</DataSourceName>
        <CommandText>wouldntyouliketoknow</CommandText>
        <Timeout>30</Timeout>
      </Query>
    </DataSet>
  </DataSets>
  <Width>7.125in</Width>
  <Body>
    <ReportItems>
      <Textbox Name='headerbox1'>
        <Width>10cm</Width>
        <Style>
          <Color>ForestGreen</Color>
          <FontSize>20pt</FontSize>
          <FontWeight>700</FontWeight>
          <PaddingLeft>2pt</PaddingLeft>
          <PaddingRight>2pt</PaddingRight>
          <PaddingTop>2pt</PaddingTop>
          <PaddingBottom>2pt</PaddingBottom>
        </Style>
        <ZIndex>2</ZIndex>
        <CanGrow>true</CanGrow>
        <Height>1cm</Height>
        <Value>MiSMDR Call Summary</Value>
      </Textbox>
      <Textbox Name='headerbox2'>
        <Top>0.5cm</Top>
        <Width>2.85714cm</Width>
        <Style>
          <Color>ForestGreen</Color>
          <FontWeight>700</FontWeight>
          <TextAlign>Right</TextAlign>
          <PaddingLeft>2pt</PaddingLeft>
          <PaddingRight>2pt</PaddingRight>
          <PaddingTop>2pt</PaddingTop>
          <PaddingBottom>2pt</PaddingBottom>
        </Style>
        <ZIndex>1</ZIndex>
        <CanGrow>true</CanGrow>
        <Left>13.05cm</Left>
        <Height>0.5cm</Height>
        <Value>Total Cost:</Value>
      </Textbox>
      <Textbox Name='headerbox4'>
        <Top>0.5cm</Top>
        <Width>2.12698cm</Width>
        <Style>
          <FontWeight>700</FontWeight>
          <TextAlign>Left</TextAlign>
          <PaddingLeft>2pt</PaddingLeft>
          <PaddingRight>2pt</PaddingRight>
          <PaddingTop>2pt</PaddingTop>
          <PaddingBottom>2pt</PaddingBottom>
          <Format>C</Format>
          <Language>" + CultureInfo.CurrentCulture.Name + @"</Language>
        </Style>
        <ZIndex>3</ZIndex>
        <CanGrow>true</CanGrow>
        <Left>15.87302cm</Left>
        <Height>0.5cm</Height>
        <Value>=Sum(Fields!Cost.Value)</Value>
      </Textbox>
      <Table Name='table1'>
        <Top>1.5cm</Top>
        <TableGroups>
          <TableGroup>
            <Grouping Name='table1_Caller_Number'>
              <GroupExpressions>
                <GroupExpression>=Fields!Caller_Number.Value</GroupExpression>
              </GroupExpressions>
            </Grouping>
            <Sorting>
              <SortBy>
                <SortExpression>=Fields!Caller_Number.Value</SortExpression>
                <Direction>Ascending</Direction>
              </SortBy>
            </Sorting>
            <Header>
              <TableRows>
                <TableRow>
                  <TableCells>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='textboxx1'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#eeeeee</BackgroundColor>
                            <FontWeight>700</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>14</ZIndex>
                          <Width>5cm</Width>
                          <CanGrow>true</CanGrow>
                          <Value>=Fields!Caller_Name.Value + "" ("" + Fields!Caller_Number.Value + "")""</Value>
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='textboxx2'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#eeeeee</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>13</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='textboxx5'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#eeeeee</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>12</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='textboxx6'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#eeeeee</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>11</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='textboxx7'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#eeeeee</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>10</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                  </TableCells>
                  <Height>0.25in</Height>
                </TableRow>
              </TableRows>
            </Header>
            <Footer>
              <TableRows>
                <TableRow>
                  <TableCells>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='fotextbox21'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#ffffff</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>9</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='fotextbox22'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#ffffff</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>8</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='fotextbox25'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#ffffff</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>7</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value />
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                        <Textbox Name='ftextbox25'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#ffffff</BackgroundColor>
                            <FontWeight>700</FontWeight>
                            <TextAlign>Right</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                          </Style>
                          <ZIndex>6</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value>Sub-total:</Value>
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                    <TableCell>
                      <ReportItems>
                         <Textbox Name='ftextbox26'>
                          <Style>
                            <Color>#000000</Color>
                            <BackgroundColor>#ffffff</BackgroundColor>
                            <FontWeight>100</FontWeight>
                            <TextAlign>Left</TextAlign>
                            <PaddingLeft>2pt</PaddingLeft>
                            <PaddingRight>2pt</PaddingRight>
                            <PaddingTop>2pt</PaddingTop>
                            <PaddingBottom>2pt</PaddingBottom>
                            <Format>C</Format>
                            <Language>" + CultureInfo.CurrentCulture.Name + @"</Language>
                          </Style>
                          <ZIndex>5</ZIndex>
                          <CanGrow>true</CanGrow>
                          <Value>=Sum(Fields!Cost.Value)</Value>
                        </Textbox>
                      </ReportItems>
                    </TableCell>
                  </TableCells>
                  <Height>0.25in</Height>
                </TableRow>
              </TableRows>
            </Footer>
          </TableGroup>
        </TableGroups>
        <Width>18cm</Width>
        <Details>
          <TableRows>
            <TableRow>
              <TableCells>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox14'>
                      <Style>
                        <Color>#000000</Color>
                        <BackgroundColor>#ffffff</BackgroundColor>
                        <FontWeight>100</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                        <Language>" + CultureInfo.CurrentCulture.Name + @"</Language>
                      </Style>
                      <ZIndex>4</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>=Fields!Call_Date.Value</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox15'>
                      <Style>
                        <Color>#000000</Color>
                        <BackgroundColor>#ffffff</BackgroundColor>
                        <FontWeight>100</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>3</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>=Fields!Duration.Value</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox18'>
                      <Style>
                        <Color>#000000</Color>
                        <BackgroundColor>#ffffff</BackgroundColor>
                        <FontWeight>100</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>2</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>=iif(Fields!Receiver_Name.Value = """", ""Unknown"", Fields!Receiver_Name.Value )</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox19'>
                      <Style>
                        <Color>#000000</Color>
                        <BackgroundColor>#ffffff</BackgroundColor>
                        <FontWeight>100</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>1</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>=Fields!Receiver_Number.Value</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox20'>
                      <Style>
                        <Color>#000000</Color>
                        <BackgroundColor>#ffffff</BackgroundColor>
                        <FontWeight>100</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>2pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                        <Format>C</Format>
                        <Language>" + CultureInfo.CurrentCulture.Name + @"</Language>
                      </Style>
                      <CanGrow>true</CanGrow>
                      <Value>=Fields!Cost.Value</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
              </TableCells>
              <Height>0.25in</Height>
            </TableRow>
          </TableRows>
        </Details>
        <Header>
          <TableRows>
            <TableRow>
              <TableCells>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox2'>
                      <Style>
                        <Color>#FFFFFF</Color>
                        <BackgroundColor>ForestGreen</BackgroundColor>
                        <FontWeight>900</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>3pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>19</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>Call Date</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox3'>
                      <Style>
                        <Color>#FFFFFF</Color>
                        <BackgroundColor>ForestGreen</BackgroundColor>
                        <FontWeight>900</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>3pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>18</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>Duration</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox6'>
                      <Style>
                        <Color>#FFFFFF</Color>
                        <BackgroundColor>ForestGreen</BackgroundColor>
                        <FontWeight>900</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>3pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>17</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>Receiver Name</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox7'>
                      <Style>
                        <Color>#FFFFFF</Color>
                        <BackgroundColor>ForestGreen</BackgroundColor>
                        <FontWeight>900</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>3pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>16</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>Receiver Number</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
                <TableCell>
                  <ReportItems>
                    <Textbox Name='textbox8'>
                      <Style>
                        <Color>#FFFFFF</Color>
                        <BackgroundColor>ForestGreen</BackgroundColor>
                        <FontWeight>900</FontWeight>
                        <TextAlign>Left</TextAlign>
                        <PaddingLeft>2pt</PaddingLeft>
                        <PaddingRight>2pt</PaddingRight>
                        <PaddingTop>3pt</PaddingTop>
                        <PaddingBottom>2pt</PaddingBottom>
                      </Style>
                      <ZIndex>15</ZIndex>
                      <CanGrow>true</CanGrow>
                      <Value>Cost</Value>
                    </Textbox>
                  </ReportItems>
                </TableCell>
              </TableCells>
              <Height>0.25in</Height>
            </TableRow>
          </TableRows>
          <RepeatOnNewPage>true</RepeatOnNewPage>
        </Header>
        <TableColumns>
          <TableColumn>
            <Width>5cm</Width>
          </TableColumn>
          <TableColumn>
            <Width>2.5cm</Width>
          </TableColumn>
          <TableColumn>
            <Width>4cm</Width>
          </TableColumn>
          <TableColumn>
            <Width>4.5cm</Width>
          </TableColumn>
          <TableColumn>
            <Width>2cm</Width>
          </TableColumn>
        </TableColumns>
      </Table>
    </ReportItems>
    <Height>1.59062in</Height>
  </Body>
  <Language>en-US</Language>
  <TopMargin>0.2in</TopMargin>
</Report>";
        }

        public string GetRdlcString(int groupedColumn)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(result);

            XmlTextWriter _rdl = new XmlTextWriter(writer);

            DataTable data = _data.Tables[0];

            _rdl.Formatting = Formatting.Indented;
            _rdl.Indentation = 3;
            _rdl.Namespaces = true;

            int _columns = data.Columns.Count;

            try
            {
                _rdl.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"utf-8\"");

                //Report

                _rdl.WriteStartElement("", "Report", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
                //_rdl.WriteAttributeString("xmlns:rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");

                #region RDL Header Section (settings)

                _rdl.WriteStartElement("", "BottomMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "RightMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "InteractiveWidth", null);
                _rdl.WriteString("7in");
                _rdl.WriteEndElement();

                #endregion

                #region Data Set

                // DataSource element
                _rdl.WriteStartElement("DataSources");
                _rdl.WriteStartElement("DataSource");
                _rdl.WriteAttributeString("Name", null, data.DataSet.DataSetName);
                _rdl.WriteStartElement("ConnectionProperties");
                _rdl.WriteElementString("DataProvider", "Oracle");
                _rdl.WriteElementString("ConnectString", "ItsaSecret");
                _rdl.WriteElementString("IntegratedSecurity", "true");
                _rdl.WriteEndElement(); // ConnectionProperties
                _rdl.WriteEndElement(); // DataSource
                _rdl.WriteEndElement(); // DataSources

                // DataSet element
                _rdl.WriteStartElement("DataSets");
                _rdl.WriteStartElement("DataSet");
                _rdl.WriteAttributeString("Name", null, data.DataSet.DataSetName);

                // Query element
                _rdl.WriteStartElement("Query");
                _rdl.WriteElementString("DataSourceName", data.DataSet.DataSetName);
                _rdl.WriteElementString("CommandType", "Text");
                _rdl.WriteElementString("CommandText", "wouldntyouliketoknow");
                _rdl.WriteElementString("Timeout", "30");
                _rdl.WriteEndElement(); // Query



                // Fields elements
                _rdl.WriteStartElement("Fields");

                for (int x = 0; x < _columns; x++)
                {
                    _rdl.WriteStartElement("Field");
                    _rdl.WriteAttributeString("Name", null, data.Columns[x].ColumnName);
                    _rdl.WriteElementString("DataField", null, data.Columns[x].ColumnName);
                    _rdl.WriteEndElement(); // Field
                }

                // End previous elements
                _rdl.WriteEndElement(); // Fields
                _rdl.WriteEndElement(); // DataSet
                _rdl.WriteEndElement(); // DataSets


                #endregion

                _rdl.WriteStartElement("", "Body", null);

                _rdl.WriteStartElement("", "ReportItems", null);

                #region Header Text
                _rdl.WriteStartElement("", "Textbox", null);
                _rdl.WriteAttributeString("Name", "headerbox1");

                _rdl.WriteStartElement("", "Width", null);
                _rdl.WriteString("10cm");
                _rdl.WriteEndElement(); // Top

                _rdl.WriteStartElement("", "Style", null);
                _rdl.WriteStartElement("", "Color", null);
                _rdl.WriteString("ForestGreen");
                _rdl.WriteEndElement(); // Color
                _rdl.WriteStartElement("", "FontFamily", null);
                _rdl.WriteString("Arial");
                _rdl.WriteEndElement(); // FontFamily
                _rdl.WriteStartElement("", "FontSize", null);
                _rdl.WriteString("20pt");
                _rdl.WriteEndElement(); // FontSize
                _rdl.WriteStartElement("", "FontWeight", null);
                _rdl.WriteString("700");
                _rdl.WriteEndElement(); // FontWeight
                _rdl.WriteStartElement("", "PaddingLeft", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingLeft
                _rdl.WriteStartElement("", "PaddingRight", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingRight
                _rdl.WriteStartElement("", "PaddingTop", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingTop
                _rdl.WriteStartElement("", "PaddingBottom", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingBottom
                _rdl.WriteEndElement(); // Style

                _rdl.WriteStartElement("", "ZIndex", null);
                _rdl.WriteString("1");
                _rdl.WriteEndElement(); // ZIndex
                _rdl.WriteStartElement("", "CanGrow", null);
                _rdl.WriteString("true");
                _rdl.WriteEndElement(); // CanGrow
                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("1cm");
                _rdl.WriteEndElement(); // Height
                _rdl.WriteStartElement("", "Value", null);
                _rdl.WriteString("MiSMDR Call Summary");
                _rdl.WriteEndElement(); // Value

                _rdl.WriteEndElement(); //Textbox

                _rdl.WriteStartElement("", "Textbox", null);
                _rdl.WriteAttributeString("Name", "headerbox2");

                _rdl.WriteStartElement("", "Style", null);
                _rdl.WriteStartElement("", "Color", null);
                _rdl.WriteString("ForestGreen");
                _rdl.WriteEndElement(); // Color
                _rdl.WriteStartElement("", "FontFamily", null);
                _rdl.WriteString("Arial");
                _rdl.WriteEndElement(); // FontFamily
                _rdl.WriteStartElement("", "FontWeight", null);
                _rdl.WriteString("700");
                _rdl.WriteEndElement(); // FontWeight
                _rdl.WriteStartElement("", "TextAlign", null);
                _rdl.WriteString("Right");
                _rdl.WriteEndElement(); // TextAlign
                _rdl.WriteStartElement("", "PaddingLeft", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingLeft
                _rdl.WriteStartElement("", "PaddingRight", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingRight
                _rdl.WriteStartElement("", "PaddingTop", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingTop
                _rdl.WriteStartElement("", "PaddingBottom", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingBottom
                _rdl.WriteEndElement(); // Style

                _rdl.WriteStartElement("", "ZIndex", null);
                _rdl.WriteString("1");
                _rdl.WriteEndElement(); // ZIndex
                _rdl.WriteStartElement("", "Width", null);
                _rdl.WriteString("3cm");
                _rdl.WriteEndElement(); // Width
                _rdl.WriteStartElement("", "Top", null);
                _rdl.WriteString("0.5cm");
                _rdl.WriteEndElement(); // Top
                _rdl.WriteStartElement("", "Left", null);
                _rdl.WriteString("13cm");
                _rdl.WriteEndElement(); // Left
                _rdl.WriteStartElement("", "CanGrow", null);
                _rdl.WriteString("true");
                _rdl.WriteEndElement(); // CanGrow
                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.5cm");
                _rdl.WriteEndElement(); // Height
                _rdl.WriteStartElement("", "Value", null);
                _rdl.WriteString("Total Cost: ");
                _rdl.WriteEndElement(); // Value

                _rdl.WriteEndElement(); //Textbox


                _rdl.WriteStartElement("", "Textbox", null);
                _rdl.WriteAttributeString("Name", "headerbox3");

                _rdl.WriteStartElement("", "Style", null);
                _rdl.WriteStartElement("", "FontFamily", null);
                _rdl.WriteString("Arial");
                _rdl.WriteEndElement(); // FontFamily
                _rdl.WriteStartElement("", "PaddingLeft", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingLeft
                _rdl.WriteStartElement("", "PaddingRight", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingRight
                _rdl.WriteStartElement("", "PaddingTop", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingTop
                _rdl.WriteStartElement("", "PaddingBottom", null);
                _rdl.WriteString("2pt");
                _rdl.WriteEndElement(); // PaddingBottom
                _rdl.WriteEndElement(); // Style

                _rdl.WriteStartElement("", "ZIndex", null);
                _rdl.WriteString("1");
                _rdl.WriteEndElement(); // ZIndex
                _rdl.WriteStartElement("", "Top", null);
                _rdl.WriteString("0.5cm");
                _rdl.WriteEndElement(); // Top
                _rdl.WriteStartElement("", "Left", null);
                _rdl.WriteString("14cm");
                _rdl.WriteEndElement(); // Left
                _rdl.WriteStartElement("", "CanGrow", null);
                _rdl.WriteString("true");
                _rdl.WriteEndElement(); // CanGrow
                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.63cm");
                _rdl.WriteEndElement(); // Height
                _rdl.WriteStartElement("", "Value", null);
                _rdl.WriteString("=\"Total:\" Sum(Fields!Cost.Value)");
                _rdl.WriteEndElement(); // Value

                _rdl.WriteEndElement(); //Textbox
                #endregion

                _rdl.WriteStartElement("", "Table", null);
                _rdl.WriteAttributeString("Name", "table1");

                #region MiSMDRCustomAdditions

                _rdl.WriteStartElement("", "TableGroups", null);
                _rdl.WriteStartElement("", "TableGroup", null);
                _rdl.WriteStartElement("", "Grouping", null);
                _rdl.WriteAttributeString("Name", "table1_" + data.Columns[groupedColumn].ColumnName);
                _rdl.WriteStartElement("", "GroupExpressions", null);
                _rdl.WriteStartElement("", "GroupExpression", null);
                _rdl.WriteString("=Fields!" + data.Columns[groupedColumn].ColumnName + ".Value");
                _rdl.WriteEndElement();//GroupExpression
                _rdl.WriteEndElement();//GroupExpressions
                _rdl.WriteEndElement();//Grouping

                _rdl.WriteStartElement("", "Sorting", null);
                _rdl.WriteStartElement("", "SortBy", null);
                _rdl.WriteStartElement("", "SortExpression", null);
                _rdl.WriteString("=Fields!"+data.Columns[groupedColumn].ColumnName+".Value");
                _rdl.WriteEndElement();//SortExpression
                _rdl.WriteStartElement("", "Direction", null);
                _rdl.WriteString("Ascending");
                _rdl.WriteEndElement();//Direction
                _rdl.WriteEndElement();//SortBy
                _rdl.WriteEndElement();//Sorting

                #endregion


                #region GroupHeader

                _rdl.WriteStartElement("", "Header", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                int _headerIndex = 1;

                int fzindex = (_headerIndex + 0);
                //add the first cell manually
                AddCell(_rdl, "textboxx" + fzindex, System.Drawing.ColorTranslator.ToHtml(BackgroundColorHeader), System.Drawing.ColorTranslator.ToHtml(TextColorHeader), TextAlignFooter, 700, fzindex, "=Fields!Caller_Name.Value + \" (\" + Fields!Caller_Number.Value + \")\"");

                //write all the header items
                for (int x = 1; x < _columns; x++)
                {
                    int _zindex = (_headerIndex + x);
                    string _name = "textboxx" + _zindex;

                    string _value = data.Columns[x].ColumnName.Replace('_',' '); // replace underscores with spaces

                    //Allow the user to override and use the default column name by passing in an empty string
                    if (x < _headers.Length && !string.IsNullOrEmpty(_headers[x]))
                    {
                        _value = _headers[x];
                    }

                    string _bgColor = System.Drawing.ColorTranslator.ToHtml(BackgroundColorHeader);
                    string _textColor = System.Drawing.ColorTranslator.ToHtml(TextColorHeader);

                    if ((x != 2) && (x != 3))
                    {
                        AddCell(_rdl, _name, _bgColor, _textColor, TextAlignFooter, 0, _zindex, "");
                    }
                }

                _rdl.WriteEndElement();//end TableCells

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();

                _rdl.WriteEndElement();//end TableRow
                _rdl.WriteEndElement();//end TableRows
                _rdl.WriteEndElement();//end Header

                #endregion

                #region Footer
                _rdl.WriteStartElement("", "Footer", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                int _footerIndex = _columns * 3;

                //write all the footer items (minus the sum of cost)
                int nx=0;
                for (int x = 0; x < _columns-2; x++)
                {
                    int _zindex = (_footerIndex + x);
                    string _name = "fotextbox" + _zindex;

                    string _bgColor = System.Drawing.ColorTranslator.ToHtml(BackgroundColorFooter);
                    string _textColor = System.Drawing.ColorTranslator.ToHtml(TextColorFooter);

                    if ((x != 2) && (x != 3))
                    {
                        AddCell(_rdl, _name, _bgColor, _textColor, TextAlignFooter, 0, _zindex, "");
                    }
                    nx = x;
                }
                //add the cell containing the cost summary
                int nzindex = (_footerIndex + nx);
                string nname = "ftextbox" + nzindex;
                AddCell(_rdl, nname, System.Drawing.ColorTranslator.ToHtml(BackgroundColorFooter), System.Drawing.ColorTranslator.ToHtml(TextColorFooter), "Right", 0, nzindex, "Total Cost:");
                nzindex++;
                nname = "ftextbox" + nzindex;
                AddCell(_rdl, nname, System.Drawing.ColorTranslator.ToHtml(BackgroundColorFooter), System.Drawing.ColorTranslator.ToHtml(TextColorFooter), TextAlignFooter, 0, nzindex, "=Sum(Fields!Cost.Value)");

                #endregion

                //end TableCells
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();


                _rdl.WriteEndElement();//end TableRow
                _rdl.WriteEndElement();//end TableRows
                _rdl.WriteEndElement();//end footer

                _rdl.WriteEndElement();//end TableGroup
                _rdl.WriteEndElement();//end TableGroups

                _rdl.WriteStartElement("", "Top", null);
                _rdl.WriteString("0.625in");
                _rdl.WriteEndElement();

                #region Details

                _rdl.WriteStartElement("", "Details", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                int _detailIndex = _columns * 2;

                //write all the detail items
                for (int x = 0; x < _columns; x++)
                {
                    int _zindex = (_detailIndex + x);
                    string _name = "textbox" + _zindex;
                    string _value = "";
                    if (x == 4) _value = "=iif(Fields!" + data.Columns[x].ColumnName + ".Value = \"\", \"Unknown\",\"\")"; // if Receiver Name field then we replace with "Unknown"
                    else _value = "=Fields!" + data.Columns[x].ColumnName + ".Value";
                    
                    //Alternate the colors by row
                    //string _bgcolor = "=iif(RowNumber(Nothing) Mod 2, \"" + System.Drawing.ColorTranslator.ToHtml(BackgroundColorBody) + "\", \"" + System.Drawing.ColorTranslator.ToHtml(BackgroundColorBodyAlternate) + "\")";
                    //string _textcolor = "=iif(RowNumber(Nothing) Mod 2, \"" + System.Drawing.ColorTranslator.ToHtml(TextColorBody) + "\", \"" + System.Drawing.ColorTranslator.ToHtml(TextColorBodyAlternate) + "\")";

                    string _bgcolor = System.Drawing.ColorTranslator.ToHtml(BackgroundColorBody);
                    string _textcolor = System.Drawing.ColorTranslator.ToHtml(TextColorBody);

                    if ((x != 2) && (x != 3))
                    {
                        AddCell(_rdl, _name, _bgcolor, _textcolor, TextAlignFooter, 0, _zindex, _value);
                    }
                }

                //end TableCells
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();

                //end TableRow
                _rdl.WriteEndElement();

                //end TableRows
                _rdl.WriteEndElement();

                //end detail
                _rdl.WriteEndElement();

                #endregion

                #region MainHeader

                _rdl.WriteStartElement("", "Header", null);
                _rdl.WriteStartElement("", "TableRows", null);
                _rdl.WriteStartElement("", "TableRow", null);
                _rdl.WriteStartElement("", "TableCells", null);

                _headerIndex = 2;

                //write all the header items
                for (int x = 0; x < _columns; x++)
                {
                    int _zindex = (_headerIndex + x);
                    string _name = "textbox" + _zindex;

                    string _value = data.Columns[x].ColumnName.Replace('_',' ');

                    //Allow the user to override and use the default column name by passing in an empty string
                    if (x < _headers.Length && !string.IsNullOrEmpty(_headers[x]))
                    {
                        _value = _headers[x];
                    }

                    string _bgColor = "ForestGreen";
                    string _textColor = System.Drawing.ColorTranslator.ToHtml(TextColorHeader);

                    int _width;
                    switch (x)
                    {
                        case 0:
                            _width = 600; //Call Date;
                            break;
                        case 1:
                            _width = 400; // Duration;
                            break;
                        case 2:
                            _width = 600; // Caller Name
                            break;
                        case 3:
                            _width = 200; // Caller Number
                            break;
                        case 4:
                            _width = 600; // Receiver Name
                            break;
                        case 5:
                            _width = 300; // Receiver Number
                            break;
                        case 6:
                            _width = 300; // Cost
                            break;
                        default:
                            _width = 400;
                            break;
                    }
                    if ((x != 2) && (x != 3))
                    {
                        AddCell(_rdl, _name, _bgColor, _textColor, TextAlignFooter, _width, _zindex, _value);
                    }
                }

                _rdl.WriteEndElement();//end TableCells

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.25in");
                _rdl.WriteEndElement();
                
                _rdl.WriteEndElement();//end TableRow
                _rdl.WriteEndElement();//end TableRows

                _rdl.WriteStartElement("", "RepeatOnNewPage", null);
                _rdl.WriteString("true");
                _rdl.WriteEndElement();
                
                _rdl.WriteEndElement();//end Header

                #endregion


                #region Table Settings

                _rdl.WriteStartElement("", "TableColumns", null);

                for (int x = 0; x < _columns; x++)
                {
                    if ((x != 2) && (x != 3))
                    {
                        double _width;
                        switch (x)
                        {
                            case 0:
                                _width = 5; //Call Date;
                                break;
                            case 1:
                                _width = 2.5; // Duration;
                                break;
                            case 2:
                                _width = 0; // Caller Name
                                break;
                            case 3:
                                _width = 0; // Caller Number
                                break;
                            case 4:
                                _width = 4; // Receiver Name
                                break;
                            case 5:
                                _width = 4.5; // Receiver Number
                                break;
                            case 6:
                                _width = 2; // Cost
                                break;
                            default:
                                _width = 4;
                                break;
                        }
                        _rdl.WriteStartElement("", "TableColumn", null);
                        _rdl.WriteStartElement("", "Width", null);
                        _rdl.WriteString(_width.ToString(CultureInfo.InvariantCulture)+"cm");
                        _rdl.WriteEndElement();

                        //end TableColumn
                        _rdl.WriteEndElement();
                    }
                }

                //end TableColumns
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("0.75in");
                _rdl.WriteEndElement();

                #endregion

                //end Table
                _rdl.WriteEndElement();

                //end ReportItems
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Height", null);
                _rdl.WriteString("1in");
                _rdl.WriteEndElement();

                //end Body
                _rdl.WriteEndElement();

                #region Document Footer Section (settings)

                _rdl.WriteStartElement("", "LeftMargin", null);
                _rdl.WriteString("0.5in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Width", null);
                _rdl.WriteString("7in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "InteractiveHeight", null);
                _rdl.WriteString("13in");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "Language", null);
                _rdl.WriteString("en-US");
                _rdl.WriteEndElement();

                _rdl.WriteStartElement("", "TopMargin", null);
                _rdl.WriteString("0.2in");
                _rdl.WriteEndElement();

                #endregion

                //End of report
                _rdl.WriteEndElement();

                //write the document to the memory stream
                _rdl.Flush();

                return result.ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                //close the document
                _rdl.Close();
            }
        }

        private static void AddCell(XmlTextWriter _writer, string name, string backgroundColor, string textColor,
            string textAlign, int fontWeight, int ZIndex, string value)
        {
            _writer.WriteStartElement("", "TableCell", null);
            _writer.WriteStartElement("", "ReportItems", null);

            _writer.WriteStartElement("", "Textbox", null);
            _writer.WriteAttributeString("Name", name);

            _writer.WriteStartElement("", "ZIndex", null);
            _writer.WriteString(ZIndex.ToString(CultureInfo.InvariantCulture));
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "Style", null);

            _writer.WriteStartElement("", "TextAlign", null);
            _writer.WriteString(textAlign);
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "Color", null);
            _writer.WriteString(textColor);
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "BackgroundColor", null);
            _writer.WriteString(backgroundColor);
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "FontWeight", null);
            if (fontWeight == 0)
            {
                _writer.WriteString("100");
            }
            else
            {
                _writer.WriteString(fontWeight.ToString(CultureInfo.InvariantCulture));
            }
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "PaddingLeft", null);
            _writer.WriteString("2pt");
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "PaddingBottom", null);
            _writer.WriteString("2pt");
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "PaddingRight", null);
            _writer.WriteString("2pt");
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "PaddingTop", null);
            _writer.WriteString("2pt");
            _writer.WriteEndElement();

            //end Style
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "CanGrow", null);
            _writer.WriteString("true");
            _writer.WriteEndElement();

            _writer.WriteStartElement("", "Value", null);
            _writer.WriteString(value);
            _writer.WriteEndElement();

            //end TextBox
            _writer.WriteEndElement();

            //End ReportItems
            _writer.WriteEndElement();

            //end TableCell
            _writer.WriteEndElement();
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        // Following is not IDisposable interface method. But added in this 
        // region/section as it is more related to Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose in thie block, only managed resources
                if (disposing)
                {
                    _fontFamilyHeader.Dispose();
                    _fontFamilyBody.Dispose();
                    _fontFamilyFooter.Dispose();
                    _data.Dispose();
                }

                // Free only un-managed resources here

            }

            disposed = true;
        }

        #endregion
    }
}
