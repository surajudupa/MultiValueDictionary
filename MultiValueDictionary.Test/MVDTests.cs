using MultiValueDictionary.CommandExecutors;
using NUnit.Framework;

namespace MultiValueDictionary.Test
{
    public class Tests
    {

        public static string[] addCommands;
        public static string[] addCommandsNegative;
        public static string[] addCommandsNegative_1;
        public static string[] memberCommand;



        public static string[] keysCommand;


        [SetUp]
        public void Setup()
        {

            addCommands = new string[] { "Add", "foo", "bar" };
            keysCommand = new string[] { "keys" };
            addCommandsNegative = new string[] { "Add" };
            addCommandsNegative_1 = new string[] { "Add", "Add", "foo", "bar" };
            memberCommand = new string[] { "Members", "foo" };

        }

        [Test]
        public void AddTest()
        {
            var addCommand = new AddCommandExecutor();
            var result = addCommand.ExecuteCommand(addCommands);

            var result_2 = addCommand.ExecuteCommand(addCommands);

            Assert.AreEqual("ADDED", result);
            Assert.AreEqual("Error, member already exists for key", result_2);

            MultiValueDictionary.ClearDictionary();
        }
        [Test]
        public void KeysTest()
        {

            var keysExec = new KeysCommandExecutor();
            var result_1 = keysExec.ExecuteCommand(keysCommand);

            var addCommand = new AddCommandExecutor();
            var result = addCommand.ExecuteCommand(addCommands);

            var result_2 = keysExec.ExecuteCommand(keysCommand);


            Assert.AreEqual("Success", result_2);
            Assert.AreEqual("(empty set)", result_1);

            MultiValueDictionary.ClearDictionary();

        }

        [Test]
        public void MemberTest()
        {
            var addCommand = new AddCommandExecutor();
            var result = addCommand.ExecuteCommand(addCommands);
            var memExec = new MembersCommandExecutor();
            var result_1 = memExec.ExecuteCommand(memberCommand);

            MultiValueDictionary.ClearDictionary();

            var result_2 = memExec.ExecuteCommand(memberCommand);


            Assert.AreEqual("Success", result_1);
            Assert.AreEqual("ERROR, Key does not exist", result_2);

            MultiValueDictionary.ClearDictionary();

        }
        [Test]
        public void ValidationTests()
        {
            var commandUtils = new CommandUtils();

            var result_1 = commandUtils.ValidateCommand(new string[] { });
            Assert.AreEqual(false, result_1.Item2);

            result_1 = commandUtils.ValidateTwoCommand(keysCommand);
            Assert.AreEqual(false, result_1.Item2);

            result_1 = commandUtils.ValidateTwoCommand(addCommandsNegative_1);
            Assert.AreEqual(false, result_1.Item2);

            result_1 = commandUtils.ValidateTwoCommand(memberCommand);
            Assert.AreEqual(true, result_1.Item2);

            result_1 = commandUtils.ValidateThreeCommand(keysCommand);
            Assert.AreEqual(false, result_1.Item2);

            result_1 = commandUtils.ValidateThreeCommand(addCommandsNegative_1);
            Assert.AreEqual(false, result_1.Item2);

            result_1 = commandUtils.ValidateThreeCommand(addCommands);
            Assert.AreEqual(true, result_1.Item2);
        }
    }
}