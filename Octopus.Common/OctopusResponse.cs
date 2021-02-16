using System;
using System.Collections.Generic;

namespace Octopus.Common
{
    public class OctopusResponse
    {
        public bool IsSuccess { get; }

        public List<Dictionary<string, dynamic>> Content { get; }

        public string ErrorMessage { get; }

        public OctopusResponse(bool isSuccess, List<Dictionary<string, dynamic>> content, string errorMessage)
        {
            IsSuccess = isSuccess;
            Content = content;
            ErrorMessage = errorMessage;
        }

        public static OctopusResponse CreateSuccessful(List<Dictionary<string, dynamic>> content)
        {
            return new OctopusResponse(true, content, null);
        }

        public static OctopusResponse CreateFailure(string errorMessage)
        {
            return new OctopusResponse(false, null, errorMessage);
        }
    }
}
