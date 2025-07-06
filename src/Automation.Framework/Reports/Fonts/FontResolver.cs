using PdfSharp.Fonts;

namespace Automation.Framework.Reports.Fonts;

public class FontResolver : IFontResolver
{
    public byte[] GetFont(string faceName)
    {
        return faceName switch
        {
            Fonts.CourierNewRegular => File.ReadAllBytes($"{PathFinder.Fonts}\\cour.ttf"),
            Fonts.CourierNewBold => File.ReadAllBytes($"{PathFinder.Fonts}\\courbd.ttf"),
            Fonts.CourierNewItalic => File.ReadAllBytes($"{PathFinder.Fonts}\\couri.ttf"),
            Fonts.CourierNewBoldItalic => File.ReadAllBytes($"{PathFinder.Fonts}\\courbi.ttf"),
            _ => throw new InvalidOperationException($"Font face '{faceName}' not handled.")
        };
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        if (familyName.Equals("Courier New", StringComparison.OrdinalIgnoreCase))
        {
            if (isBold && isItalic)
                return new FontResolverInfo(Fonts.CourierNewBoldItalic);
            if (isBold)
                return new FontResolverInfo(Fonts.CourierNewBold);
            if (isItalic)
                return new FontResolverInfo(Fonts.CourierNewItalic);

            return new FontResolverInfo(Fonts.CourierNewRegular);
        }

        return new FontResolverInfo(Fonts.CourierNewRegular);
    }
}
