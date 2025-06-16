using Automation.Framework.Reports.Fonts;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using BorderStyle = MigraDoc.DocumentObjectModel.BorderStyle;
using Table = MigraDoc.DocumentObjectModel.Tables.Table;

namespace Automation.Framework.Reports.Pdf;

public class PdfReportGenerator
{
    public PdfReportGenerator()
    {
        GlobalFontSettings.FontResolver ??= new FontResolver();
    }

    public const string TestSummary = "Test Execution Summary";

    private static Document CreateDocument(PdfReportModel pdfReportModel)
    {
        var document = new Document
        {
            Info =
            {
                Title = pdfReportModel.Title,
                Subject = pdfReportModel.Subject,
                Author = pdfReportModel.Author
            }
        };

        var section = document.AddSection();

        DrawTable(document); // Add the test summary table
        AddTestResultPieChart(section, total: 10, passed: 8, failed: 1, skipped: 1); // Add chart after table

        var paragraph = section.AddParagraph();

        var footer = section.Footers.Primary;

        paragraph = footer.AddParagraph();
        paragraph.Add(pdfReportModel.FooterFormat);
        paragraph.Format.Alignment = pdfReportModel.FooterAlignment;

        return document;
    }

    public void GenerateReport(string filePath, string title)
    {
        var pdfReportModel = new PdfReportModel
        {
            Title = title,
            Subject = "Generated PDF Report",
            Author = "Automation Framework",
            FontColor = Colors.DarkBlue,
            FooterFormat = new DateField { Format = "yyyy/MM/dd HH:mm:ss" },
            FooterAlignment = ParagraphAlignment.Center
        };

        Document document = CreateDocument(pdfReportModel);

        var style = document.Styles[StyleNames.Normal]!;
        style.Font.Name = "Arial";

        var pdfRenderer = new PdfDocumentRenderer
        {
            Document = document,
            PdfDocument =
            {
                PageLayout = PdfPageLayout.SinglePage,
                ViewerPreferences =
                {
                    FitWindow = true
                }
            }
        };

        pdfRenderer.RenderDocument();

        string imagePath = @"C:\Users\jirai\source\repos\selenium-sharp-template\Artefacts\Reports\Screenshots\05-06-2025\Menu\Launch about us from menu\user clicks on About Us from menu_adbd5414-df10-4e5c-866f-6325a7b4906e.png";
        document.LastSection.AddImage(imagePath);

        var filename = Path.Combine(filePath, $"{title}_{Guid.NewGuid()}.pdf");
        pdfRenderer.PdfDocument.Save(filename);

        PdfFileUtility.ShowDocument(filename);
    }

    public static void DrawTable(Document document)
    {
        var paragraph = document.LastSection.AddParagraph(TestSummary, StyleNames.Heading1);
        paragraph.AddBookmark(TestSummary);

        paragraph.Format.Font.Size = 18;
        paragraph.Format.Font.Color = new Color(35, 55, 85);
        paragraph.Format.Font.Bold = true;
        paragraph.Format.Font.Italic = true;
        paragraph.Format.SpaceAfter = 20;
        paragraph.Format.Alignment = ParagraphAlignment.Center;

        var table = new Table { Borders = { Width = 0.75 } };
        table.AddColumn(Unit.FromCentimeter(5));
        table.AddColumn(Unit.FromCentimeter(12));

        var data = new (string Label, string Value)[]
        {
            ("Test Suite", "LoginTests"),
            ("Environment", "QA"),
            ("Platform", "Windows 11"),
            ("Browser", "Chrome 124"),
            ("Executed By", "CI Pipeline"),
            ("Start Time", "2025-06-16 09:00"),
            ("End Time", "2025-06-16 09:05"),
            ("Duration", "00:05:00"),
            ("Build ID", "v1.2.3")
        };

        foreach (var (label, value) in data)
        {
            var row = table.AddRow();
            row.HeightRule = RowHeightRule.AtLeast;

            var labelCell = row.Cells[0];
            labelCell.Shading.Color = new Color(35, 55, 85);
            var labelPara = labelCell.AddParagraph(label);
            labelPara.Format.Alignment = ParagraphAlignment.Left;
            labelPara.Format.SpaceBefore = 5;
            labelPara.Format.SpaceAfter = 5;
            labelPara.Format.Font.Bold = true;
            labelPara.Format.Font.Color = Colors.White;

            var valueCell = row.Cells[1];
            valueCell.Shading.Color = Colors.WhiteSmoke;
            var valuePara = valueCell.AddParagraph(value);
            valuePara.Format.Alignment = ParagraphAlignment.Left;
            valuePara.Format.SpaceBefore = 5;
            valuePara.Format.SpaceAfter = 5;
            valuePara.Format.Font.Color = Colors.Black;
        }

        table.SetEdge(0, 0, 2, data.Length, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);
        document.LastSection.Add(table);
        document.LastSection.AddParagraph().Format.SpaceBefore = 20;
    }

    private static void AddTestResultPieChart(Section section, int total, int passed, int failed, int skipped)
    {
        var chart = section.AddChart(ChartType.Pie2D);
        chart.LineFormat.Width = 0;
        chart.Width = Unit.FromCentimeter(18);
        chart.Height = Unit.FromCentimeter(14);
        chart.PlotArea.TopPadding = Unit.FromCentimeter(1);
        chart.PlotArea.BottomPadding = Unit.FromCentimeter(1);
        chart.PlotArea.LeftPadding = Unit.FromCentimeter(1);
        chart.PlotArea.RightPadding = Unit.FromCentimeter(1);

        var series = chart.SeriesCollection.AddSeries();
        series.HasDataLabel = true;
        series.DataLabel.Type = DataLabelType.Percent;
        series.DataLabel.Position = DataLabelPosition.OutsideEnd;
        series.DataLabel.Font.Size = 12;
        series.DataLabel.Font.Bold = true;

        // Add pie values and color
        series.Add(passed).FillFormat.Color = new Color(0, 128, 96);
        series.Add(failed).FillFormat.Color = new Color(192, 0, 32);
        series.Add(skipped).FillFormat.Color = new Color(64, 105, 225);

        // Manual labels with count in legend
        var xSeries = chart.XValues.AddXSeries();
        xSeries.Add(
            $"Passed  ({passed})",
            $"Failed  ({failed})",
            $"Skipped ({skipped})"
        );

        // Legend formatting
        var legend = chart.RightArea.AddLegend();
        legend.LineFormat.Width = 0;
        legend.Format.Alignment = ParagraphAlignment.Left;
        legend.Format.Font.Size = 12;
    }
}