namespace PManager {
    partial class Plugin {
        public void UpdateFileInfo(string PFolder, string name) {
            DirectoryInfo directory = new DirectoryInfo(PFolder + name);

            if(!directory.Exists) 
                throw new FormatException("This plugin hasnt createn");
        }
    }
}