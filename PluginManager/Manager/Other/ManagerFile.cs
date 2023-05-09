namespace PManager {
    class ManagerFile {
        public string? FolderPath { get; set; }
        public string Title { get; set; } = "NoName";
        public List<string> Projects { get; set; } = new List<string>();

        public ManagerFile(string path) { 
            if(Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            FolderPath = path;
        }

        public ManagerFile(string path, string title) 
            : this(path){
            Title = title;
        }

        private bool IsExistsMainFile {
            get {
                if(FolderPath == null)
                    throw new FormatException("Main Manager file doesnt create");
                
                var files = Directory.GetFiles(FolderPath);

                if(files.Length != 1)
                    throw new FormatException("Folder {FolderPath} have files!");
                
                FileInfo file = new FileInfo(files[0]);

                return file.Extension == Plugin.Extension ? true : false;
            }
        }
    
        public string StringVisual() {
            var builder = new System.Text.StringBuilder();

            builder.Append(Title + '|');

            foreach(string line in Projects) 
                builder.Append(line + '|');

            return builder.ToString();    
        }

        public void ObjectFromVisual(string visual) {
            var objects = visual.Split('|');
            int counter = 0;

            if(objects.Length < 1)
                throw new FormatException("Managment File doesnt have title");

            Title = objects[counter++];

            Projects.Clear();
            for(int i = counter; i < objects.Length; i++)
                Projects.Add(objects[i]);
        }

        public void CreateFile(string Path) {
            if(Directory.Exists(Path) == false)
                Directory.CreateDirectory(Path);

            FolderPath = Path;

            if(IsExistsMainFile)
                return;

            using(var filestream = File.Create(Path)) {
                using(var stream = new StreamWriter(filestream)) {
                    stream.Write(StringVisual());
                }
            }
        }
    }
}