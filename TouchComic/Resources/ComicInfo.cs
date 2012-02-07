﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
public partial class ComicInfo {
    
    private string titleField;
    
    private string seriesField;
    
    private string numberField;
    
    private int countField;
    
    private int volumeField;
    
    private string alternateSeriesField;
    
    private string alternateNumberField;
    
    private int alternateCountField;
    
    private string summaryField;
    
    private string notesField;
    
    private int yearField;
    
    private int monthField;
    
    private string writerField;
    
    private string pencillerField;
    
    private string inkerField;
    
    private string coloristField;
    
    private string lettererField;
    
    private string coverArtistField;
    
    private string editorField;
    
    private string publisherField;
    
    private string imprintField;
    
    private string genreField;
    
    private string webField;
    
    private int pageCountField;
    
    private string languageISOField;
    
    private string formatField;
    
    private YesNo blackAndWhiteField;
    
    private YesNo mangaField;
    
    private ComicPageInfo[] pagesField;
    
    public ComicInfo() {
        this.titleField = "";
        this.seriesField = "";
        this.numberField = "";
        this.countField = -1;
        this.volumeField = -1;
        this.alternateSeriesField = "";
        this.alternateNumberField = "";
        this.alternateCountField = -1;
        this.summaryField = "";
        this.notesField = "";
        this.yearField = -1;
        this.monthField = -1;
        this.writerField = "";
        this.pencillerField = "";
        this.inkerField = "";
        this.coloristField = "";
        this.lettererField = "";
        this.coverArtistField = "";
        this.editorField = "";
        this.publisherField = "";
        this.imprintField = "";
        this.genreField = "";
        this.webField = "";
        this.pageCountField = 0;
        this.languageISOField = "";
        this.formatField = "";
        this.blackAndWhiteField = YesNo.Unknown;
        this.mangaField = YesNo.Unknown;
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Series {
        get {
            return this.seriesField;
        }
        set {
            this.seriesField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Number {
        get {
            return this.numberField;
        }
        set {
            this.numberField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int Count {
        get {
            return this.countField;
        }
        set {
            this.countField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int Volume {
        get {
            return this.volumeField;
        }
        set {
            this.volumeField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string AlternateSeries {
        get {
            return this.alternateSeriesField;
        }
        set {
            this.alternateSeriesField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string AlternateNumber {
        get {
            return this.alternateNumberField;
        }
        set {
            this.alternateNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int AlternateCount {
        get {
            return this.alternateCountField;
        }
        set {
            this.alternateCountField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Summary {
        get {
            return this.summaryField;
        }
        set {
            this.summaryField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Notes {
        get {
            return this.notesField;
        }
        set {
            this.notesField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int Year {
        get {
            return this.yearField;
        }
        set {
            this.yearField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int Month {
        get {
            return this.monthField;
        }
        set {
            this.monthField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Writer {
        get {
            return this.writerField;
        }
        set {
            this.writerField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Penciller {
        get {
            return this.pencillerField;
        }
        set {
            this.pencillerField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Inker {
        get {
            return this.inkerField;
        }
        set {
            this.inkerField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Colorist {
        get {
            return this.coloristField;
        }
        set {
            this.coloristField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Letterer {
        get {
            return this.lettererField;
        }
        set {
            this.lettererField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string CoverArtist {
        get {
            return this.coverArtistField;
        }
        set {
            this.coverArtistField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Editor {
        get {
            return this.editorField;
        }
        set {
            this.editorField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Publisher {
        get {
            return this.publisherField;
        }
        set {
            this.publisherField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Imprint {
        get {
            return this.imprintField;
        }
        set {
            this.imprintField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Genre {
        get {
            return this.genreField;
        }
        set {
            this.genreField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Web {
        get {
            return this.webField;
        }
        set {
            this.webField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(0)]
    public int PageCount {
        get {
            return this.pageCountField;
        }
        set {
            this.pageCountField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string LanguageISO {
        get {
            return this.languageISOField;
        }
        set {
            this.languageISOField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Format {
        get {
            return this.formatField;
        }
        set {
            this.formatField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(YesNo.Unknown)]
    public YesNo BlackAndWhite {
        get {
            return this.blackAndWhiteField;
        }
        set {
            this.blackAndWhiteField = value;
        }
    }
    
    /// <remarks/>
    [System.ComponentModel.DefaultValueAttribute(YesNo.Unknown)]
    public YesNo Manga {
        get {
            return this.mangaField;
        }
        set {
            this.mangaField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Page")]
    public ComicPageInfo[] Pages {
        get {
            return this.pagesField;
        }
        set {
            this.pagesField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
public enum YesNo {
    
    /// <remarks/>
    Unknown,
    
    /// <remarks/>
    No,
    
    /// <remarks/>
    Yes,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ComicPageInfo {
    
    private int imageField;
    
    private ComicPageType typeField;
    
    private bool doublePageField;
    
    private long imageSizeField;
    
    private string keyField;
    
    private int imageWidthField;
    
    private int imageHeightField;
    
    public ComicPageInfo() {
        this.typeField = ComicPageType.Story;
        this.doublePageField = false;
        this.imageSizeField = ((long)(0));
        this.keyField = "";
        this.imageWidthField = -1;
        this.imageHeightField = -1;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Image {
        get {
            return this.imageField;
        }
        set {
            this.imageField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(ComicPageType.Story)]
    public ComicPageType Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(false)]
    public bool DoublePage {
        get {
            return this.doublePageField;
        }
        set {
            this.doublePageField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
    public long ImageSize {
        get {
            return this.imageSizeField;
        }
        set {
            this.imageSizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("")]
    public string Key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int ImageWidth {
        get {
            return this.imageWidthField;
        }
        set {
            this.imageWidthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(-1)]
    public int ImageHeight {
        get {
            return this.imageHeightField;
        }
        set {
            this.imageHeightField = value;
        }
    }
}

/// <remarks/>
[System.FlagsAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
[System.SerializableAttribute()]
public enum ComicPageType {
    
    /// <remarks/>
    FrontCover = 1,
    
    /// <remarks/>
    InnerCover = 2,
    
    /// <remarks/>
    Roundup = 4,
    
    /// <remarks/>
    Story = 8,
    
    /// <remarks/>
    Advertisment = 16,
    
    /// <remarks/>
    Editorial = 32,
    
    /// <remarks/>
    Letters = 64,
    
    /// <remarks/>
    Preview = 128,
    
    /// <remarks/>
    BackCover = 256,
    
    /// <remarks/>
    Other = 512,
    
    /// <remarks/>
    Deleted = 1024,
}
