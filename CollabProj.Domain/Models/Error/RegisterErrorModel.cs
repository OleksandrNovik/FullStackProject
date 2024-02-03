﻿namespace CollabProj.Domain.Models.Error
{
    /// <summary>
    /// Error Model for Register Form
    /// </summary>
    public class RegisterErrorModel
    {
        /// <summary>
        /// Email Error of register form.
        /// </summary>
        public string? EmailError { get; set; }

        /// <summary>
        /// Indicator of successful form submittion
        /// </summary>
        public bool Success { get; set; }
    }
}
