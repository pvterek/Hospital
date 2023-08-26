﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.UserObject;
using Hospital.Utilities;

namespace Hospital.Commands.LoginWindow
{
    /// <summary>
    /// Represents the main command to create a user account. 
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class CreateAccountCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="CreateAccountCommand"/> class.
        /// </summary>
        private static CreateAccountCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="CreateAccountCommand"/> class.
        /// </summary>
        internal static CreateAccountCommand Instance => _instance ??= new CreateAccountCommand(UIMessages.CreateAccountCommandMessages.Introduce);

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountCommand"/> class, with a specified introduction message.
        /// </summary>
        /// <param name="introduceString">The introduction message for the account creation process.</param>
        public CreateAccountCommand(string introduceString) : base(introduceString) { }

        /// <summary>
        /// Executes the account creation process, prompting the user for details and adding the newly created user to storage.
        /// </summary>
        public override void Execute()
        {
            Console.Clear();

            User user = UserFactory.CreateUser();
            Storage.users.Add(user);
            UserInterface.ShowMessage(string.Format(UIMessages.CreateAccountCommandMessages.CreatedAccountPrompt, user.Login));
        }
    }
}