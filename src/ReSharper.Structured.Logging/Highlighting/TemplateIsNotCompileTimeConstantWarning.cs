﻿using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;

using ReSharper.Structured.Logging.Highlighting;

[assembly:
    RegisterConfigurableSeverity(TemplateIsNotCompileTimeConstantWarning.SeverityId, null, HighlightingGroupIds.CompilerWarnings,
        TemplateIsNotCompileTimeConstantWarning.Message, TemplateIsNotCompileTimeConstantWarning.Message,
        Severity.WARNING)]

namespace ReSharper.Structured.Logging.Highlighting
{
    [ConfigurableSeverityHighlighting(
        SeverityId,
        CSharpLanguage.Name,
        OverlapResolve = OverlapResolveKind.WARNING,
        ToolTipFormatString = Message)]
    public class TemplateIsNotCompileTimeConstantWarning : IHighlighting
    {
        public const string SeverityId = "TemplateIsNotCompileTimeConstantProblem";

        public const string Message = "Message template should be compile time constant";

        private readonly DocumentRange _documentRange;

        public TemplateIsNotCompileTimeConstantWarning(DocumentRange documentRange)
        {
            _documentRange = documentRange;
        }

        public string ErrorStripeToolTip => ToolTip;

        public string ToolTip => Message;

        public DocumentRange CalculateRange()
        {
            return _documentRange;
        }

        public bool IsValid()
        {
            return _documentRange.IsValid();
        }
    }
}