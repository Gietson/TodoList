using System;

namespace TodoList.Domain
{
    public class Todo
    {
        public Guid Id { get; protected set; }
        public string Message { get; protected set; }
        public bool Active { get; protected set; }

        protected Todo()
        {
        }

        protected Todo(Guid id, string message, bool active)
        {
            Id = id;
            SetMessage(message);
            Active = active;
        }

        private void SetMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Message can not be empty.");
            }
            Message = message;
        }

        public static Todo Create(Guid id, string message, bool active)
            => new Todo(id, message, active);
    }
}