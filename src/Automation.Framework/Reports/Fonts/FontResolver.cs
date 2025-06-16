using PdfSharp.Fonts;

namespace Automation.Framework.Reports.Fonts;

public class FontResolver : IFontResolver
{
    private static readonly string CourierNewPath = @"C:\Windows\Fonts\cour.ttf";

    public byte[] GetFont(string faceName)
    {
        if (faceName == "CourierNew#")
            return File.ReadAllBytes(CourierNewPath);

        throw new InvalidOperationException($"Font {faceName} not handled.");
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        if (familyName.Equals("Courier New", StringComparison.OrdinalIgnoreCase))
        {
            return new FontResolverInfo("CourierNew#");
        }

        // Fallback font
        return new FontResolverInfo("CourierNew#");
    }
}
