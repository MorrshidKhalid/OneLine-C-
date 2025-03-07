﻿namespace OneLine.Wep.Models
{
    public class ResponseDTO
    {
        public object? Result { get; set; } = null;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
