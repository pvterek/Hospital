using System;
using System.Collections.Generic;
using Hospital.Commands.ManagePatients;
using Hospital.Objects;

namespace Hospital.Commands
{
    /// <summary>
    /// Represents a composite command pattern providing support for executing complex command structures.
    /// Implements the <see cref="ICommand"/> and the <see cref="IHasIntroduceString"/> interface.
    /// </summary>
    internal abstract class CompositeCommand : ICommand, IHasIntroduceString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeCommand"/> class with a given introduce string.
        /// </summary>
        /// <param name="introduceString">The value that will be displayed to represent the command in the GUI.</param>
        protected CompositeCommand(string introduceString)
        {
            IntroduceString = introduceString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeCommand"/> class with an introduce string and a list of commands.
        /// </summary>
        /// <param name="introduceString">The value that will be displayed to represent the command in the GUI.</param>
        /// <param name="commands">The list of composite commands, used in cases where the main command acts as a folder or container for other commands.</param>
        protected CompositeCommand(string introduceString, List<CompositeCommand> commands)
        {
            Commands = commands;
            IntroduceString = introduceString;
        }

        /// <summary>
        /// Gets or sets the list of composite commands.
        /// </summary>
        internal List<CompositeCommand> Commands;

        /// <summary>
        /// Gets or sets the introduce string Implemented from <see cref="IHasIntroduceString"/>
        /// </summary>
        public string IntroduceString { get; set; }

        /// <summary>
        /// Executes the command logic. Implemented from <see cref="ICommand"/>
        /// </summary>
        public abstract void Execute();
    }
}
