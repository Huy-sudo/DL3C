// <copyright file="ErrorHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DL3C_API.Infrastructure.Utility.ErrorHandling;

using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Diagnostics;

/// <inheritdoc cref="IErrorHandler"/>
public class ErrorHandler : IErrorHandler
{
    /// <inheritdoc/>
    public ValidationProblemDetails? HandlerError(Exception? exception)
    {
        if (exception == null || !(exception is CException cEx))
        {
            return null;
        }

        IDictionary<string, string[]> listError = new Dictionary<string, string[]>();

        if (cEx.ErrorMessage != null)
        {
            listError.Add(cEx.ErrorMessage.Target.ToString()!, new[] { cEx.ErrorMessage.Message });
        }

        var exceptionMessage = new ValidationProblemDetails(listError)
        {
            Status = cEx.StatusCode,
            Detail = cEx.Message,
            Title = "COLLA.Ai - " + ReasonPhrases.GetReasonPhrase(cEx.StatusCode),
            Type = "https://tools.ietf.org/html/rfc7231",
        };

        return exceptionMessage;
    }

    /// <inheritdoc/>
    public ValidationProblemDetails? UnhandledError(Exception? exception)
    {
        if (exception == null)
        {
            return null;
        }

        var exceptionMessage = new ValidationProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "COLLA - Contact Admin :))",
            Instance = exception.Message,
            Title = "COLLA.Ai - " + ReasonPhrases.GetReasonPhrase(StatusCodes.Status500InternalServerError),
        };

        return exceptionMessage;
    }

    /// <inheritdoc/>
    public ErrorLocation? GetLocation(Exception? exception)
    {
        if (exception == null)
        {
            return null;
        }

        var trace = new StackTrace(exception, fNeedFileInfo: true);

        foreach (var mainFrame in trace.GetFrames())
        {
            if (!mainFrame.GetMethod()!.IsPublic || mainFrame.GetMethod()!.ContainsGenericParameters)
            {
                continue;
            }

            var el = new ErrorLocation
            {
                BugFile = mainFrame.GetFileName()?.Split("\\").LastOrDefault(),
                BugMethod = mainFrame.GetMethod()?.ToString(),
                BugLine = mainFrame.GetFileLineNumber(),
            };

            return el;
        }

        return null;
    }
}