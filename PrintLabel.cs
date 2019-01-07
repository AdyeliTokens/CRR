using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRR.Models.Entidades.Specs;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using MigraDoc.DocumentObjectModel.Tables;

namespace CRR.Helpers
{
    public class PrintLabel
    {
        public static PdfDocument CreateDocument(Label label)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = label.ProductCode + "_" + label.ProductDescription +  "_" + DateTime.Now.ToString("yyyy-MM-dd");
            
            Document doc = new Document();
            Section section = doc.AddSection();

            //doc.DefaultPageSetup.TopMargin = 20;
            doc.DefaultPageSetup.BottomMargin = 150;
            doc.DefaultPageSetup.LeftMargin = 5;
            doc.DefaultPageSetup.RightMargin = 5;

            CreateLabel(doc, label);
            
            var pdfRenderer = new DocumentRenderer(doc);
            pdfRenderer.PrepareDocument();

            int pages = pdfRenderer.FormattedDocument.PageCount;
            for (int i = 1; i <= pages; ++i)
            {
                var page = document.AddPage();

                PageInfo pageInfo = pdfRenderer.FormattedDocument.GetPageInfo(i);
                //page.Size = PdfSharp.PageSize.A4;
                page.Width = XUnit.FromCentimeter(11);
                page.Height = XUnit.FromCentimeter(19);
                page.Orientation = PdfSharp.PageOrientation.Landscape;
                
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    gfx.MUH = PdfFontEncoding.Unicode;
                    gfx.MFEH = PdfFontEmbedding.Default;
                    pdfRenderer.RenderPage(gfx, i);
                }
            }

            return document;
        }

        public static void CreateLabel(Document document, Label label)
        {
            int header  =  8;
            int body    = 12;
            int important = 20;

            MigraDoc.DocumentObjectModel.Tables.Table table = new MigraDoc.DocumentObjectModel.Tables.Table();
            table.Borders.Width = 0.5;

            Column column = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(2));
            table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(3.5));
            table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(3.7));
            table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(2.7));
            table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(2.7));
            table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(4.5));

            Row row = table.AddRow();
            row.Shading.Color = Colors.White;
            Cell cell = row.Cells[0];
            
            #region Header           
            row.Format.Font.Size = header;
            cell = row.Cells[0];
            cell.AddParagraph("PM NUMERO DE LOTE");
            row.Cells[0].MergeRight = 1;
            cell = row.Cells[2];
            cell.AddParagraph("NUMERO CONSECUTIVO");
            row.Cells[2].MergeRight = 1;
            cell = row.Cells[4];
            cell.AddParagraph("CENTRO DE MANUFACTURA");
            row.Cells[4].MergeRight = 1;

            row = table.AddRow();
            row.Format.Font.Size = body;
            row.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[0];
            cell.AddParagraph(label.Lot);
            row.Cells[0].MergeRight = 1;
            cell = row.Cells[2];
            cell.AddParagraph(label.Consecutive);
            row.Cells[2].MergeRight = 1;
            cell = row.Cells[4];
            cell.AddParagraph(label.ManufacturingCenter);
            row.Cells[4].MergeRight = 1;
            row.Cells[4].MergeDown = 2;
            row.Cells[4].Format.Font.Size = important;

            row = table.AddRow();
            row.Format.Font.Size = header;
            cell = row.Cells[0];
            cell.AddParagraph("FECHA DE PRODUCCION");
            row.Cells[0].MergeRight = 1;
            cell = row.Cells[2];
            cell.AddParagraph("FECHA DE EXPIRACION");
            row.Cells[2].MergeRight = 1;

            row = table.AddRow();
            row.Format.Font.Size = body;
            row.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[0];
            cell.AddParagraph(label.ProductionDate.Day+"/"+ label.ProductionDate.Month + "/"+ label.ProductionDate.Year);
            row.Cells[0].MergeRight = 1;
            cell = row.Cells[2];
            cell.AddParagraph(label.ExpirationDate.Day + "/" + label.ExpirationDate.Month + "/" + label.ExpirationDate.Year);
            row.Cells[2].MergeRight = 1;
            #endregion

            #region Body
            row = table.AddRow();
            row.Format.Font.Size = header;
            cell = row.Cells[0];
            cell.AddParagraph("CODIGO DE PRODUCTO");
            row.Cells[0].MergeRight = 1;
            cell = row.Cells[2];
            cell.AddParagraph(label.BrandDescription);
            row.Cells[2].MergeRight = 3;
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].Format.Font.Size = body;

            row = table.AddRow();
            row.Format.Font.Size = 50;
            row.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[0];
            cell.AddParagraph(label.ProductCode);
            row.Cells[0].MergeRight = 5;

            row = table.AddRow();
            row.Format.Font.Size = body;
            row.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[0];
            cell.AddParagraph("DESCRIPCION DE PRODUCTO");
            row.Cells[0].MergeRight = 1;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].Format.Font.Size = header;

            var description = label.ProductDescription.Split(' ');
            cell = row.Cells[2];
            cell.AddParagraph(description[0]);
            cell = row.Cells[3];
            cell.AddParagraph(description[1]);
            row.Cells[3].MergeRight = 1;
            row.Cells[3].Format.Font.Size = important;
            cell = row.Cells[5];
            cell.AddParagraph(description[2]);            
            #endregion

            #region Footer
            row = table.AddRow();
            row.Format.Font.Size = body;
            row.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[0];
            cell.AddParagraph(label.LabelNumber);
            row.Cells[0].MergeRight = 5;
            
            row = table.AddRow();
            row.Format.Font.Size = header;
            cell = row.Cells[0];
            cell.AddParagraph("FLASH POINT");
            cell = row.Cells[1];
            cell.AddParagraph("PESO TOTAL KG");
            cell = row.Cells[2];
            cell.AddParagraph("CANTIDAD RS KG");
            cell = row.Cells[3];
            cell.AddParagraph("BANCO EXTRACCION");
            cell = row.Cells[4];
            cell.AddParagraph("MODULO EXTRACCION");
            cell = row.Cells[5];
            cell.AddParagraph("NOMBRE DEL OPERADOR");

            row = table.AddRow();
            row.Format.Font.Size = body;
            row.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[0];
            cell.AddParagraph(label.FlashPoint);
            cell = row.Cells[1];
            cell.AddParagraph(label.Weight + " KG");
            cell = row.Cells[2];
            cell.AddParagraph(label.Quantity + " KG");
            row.Cells[2].Format.Font.Size = important;
            cell = row.Cells[3];
            cell.AddParagraph(label.ExtractionBank);
            cell = row.Cells[4];
            cell.AddParagraph(label.ExtractionModule);
            cell = row.Cells[5];
            cell.AddParagraph(label.Operator);
            #endregion

            table.SetEdge(0, 0, 2, 2, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, .5, Colors.Black);

            document.LastSection.Add(table);
        }


    }
}