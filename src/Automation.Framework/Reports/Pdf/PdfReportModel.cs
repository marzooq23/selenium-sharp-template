using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;

namespace Automation.Framework.Reports.Pdf;

public class PdfReportModel
{
    public string Title { get; set; }
    public string Subject { get; set; }
    public string Author { get; set; }
    public Color FontColor { get; set; }
    public DateField FooterFormat { get; set; }
    public ParagraphAlignment FooterAlignment { get; set; }
}