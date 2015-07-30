namespace WinTail
{
    public class Messages
    {
        /// <summary>
        ///
        /// </summary>
        public class ContinueProcessing { }

        /// <summary>
        ///
        /// </summary>
        public class InputSuccess
        {
            public InputSuccess(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; private set; }
        }

        /// <summary>
        ///
        /// </summary>
        public class InputError
        {
            public InputError(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; set; }
        }

        /// <summary>
        ///
        /// </summary>
        public class NullInputError : InputError
        {
            public NullInputError(string reason)
                : base(reason)
            {
            }
        }

        public class ValidationError : InputError
        {
            public ValidationError(string reason)
                : base(reason)
            {
            }
        }
    }
}
