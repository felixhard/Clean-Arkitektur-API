﻿namespace Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> Errors { get; }

        public BadRequestException(string message, List<string> errors) : base(message)
        {
            Errors = errors;
        }
    }
}