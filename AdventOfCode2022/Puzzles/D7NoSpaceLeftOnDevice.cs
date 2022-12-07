namespace AdventOfCode2022.Puzzles
{
    //https://adventofcode.com/2022/day/7
    public static class D7NoSpaceLeftOnDevice
    {
        public static int SolvePart1(string[]? customInput = null)
        {
            var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD7.txt");
            List<Directory> allDirectories = new();
            var atMost = 100000;

            FillDirectories(input, allDirectories);

            return allDirectories.FindAll(s => s.Size < atMost).Sum(s => s.Size);
        }

        public static int SolvePart2(string[]? customInput = null)
        {
            var input = customInput ?? PuzzleInput.GetFromFileAsStrings("PuzzleInputD7.txt");
            List<Directory> allDirectories = new();
            var totalDiskSpace = 70000000;
            var requiredDiskSpace = 30000000;
            
            FillDirectories(input, allDirectories);

            var unusedDiskSpace = totalDiskSpace - allDirectories.Find(s => s.Name == "/")?.Size;

            return allDirectories.FindAll(s => (unusedDiskSpace + s.Size) >= requiredDiskSpace).Min(s => s.Size);
        }

        private static void FillDirectories(string[] input, List<Directory> allDirectories)
        {
            var currentDir = new Directory()
            {
                Name = "/",
                ContainingDirectory = null
            };
            allDirectories.Add(currentDir);

            var lsInProgress = false;
            List<Directory> dirsToAdd = null!;
            List<File> filesToAdd = null!;


            foreach (var command in input)
            {
                var splited = command.Split();
                if (splited[0] == "$")
                {
                    if (splited[1] == "cd")
                    {
                        if (splited[2] == "/") continue;

                        if (lsInProgress)
                        {
                            lsInProgress = false;
                            currentDir.Directories = dirsToAdd;
                            currentDir.Files = filesToAdd;
                            dirsToAdd = null!;
                            filesToAdd = null!;
                        }

                        if (splited[2] == "..")
                        {
                            if (currentDir.ContainingDirectory == null)
                                throw new DirectoryNotFoundException($"Current directory: \"{currentDir.Name}\", is missing parent!");
                            currentDir = currentDir.ContainingDirectory;
                        }
                        else
                        {
                            if (!currentDir.Directories.Any(s => s.Name == splited[2]))
                                throw new DirectoryNotFoundException($"Current directory: \"{currentDir.Name}\" does not contain any folder named \"{splited[2]}\"!");
                            currentDir = currentDir.Directories.Find(s => s.Name == splited[2])!;
                            allDirectories.Add(currentDir);
                        }
                    }
                    else if (splited[1] == "ls")
                    {
                        lsInProgress = true;
                        dirsToAdd = new List<Directory>();
                        filesToAdd = new List<File>();
                    }
                }
                else
                {
                    if (!lsInProgress) throw new InvalidOperationException("\"$ ls\" must be executed first!");
                    if (dirsToAdd == null || filesToAdd == null) throw new ArgumentNullException();

                    if (splited[0] == "dir")
                        dirsToAdd.Add(new Directory() { ContainingDirectory = currentDir, Name = splited[1] });
                    else
                        filesToAdd.Add(new File() { ContainingFolder = currentDir, Size = int.Parse(splited[0]), Name = splited[1] });
                }
            }

            if (lsInProgress)
            {
                lsInProgress = false;
                currentDir.Directories = dirsToAdd;
                currentDir.Files = filesToAdd;
                dirsToAdd = null!;
                filesToAdd = null!;
            }
        }
    }

    internal class Directory
    {
        internal required Directory? ContainingDirectory;
        internal List<Directory> Directories = null!;
        internal List<File> Files = null!;
        internal required string Name { get; set; }
        internal int Size => Directories.Sum(s => s.Size) + Files.Sum(s => s.Size);
    }

    internal class File
    {
        internal required Directory ContainingFolder { get; set; }
        internal required string Name { get; set; }
        internal required int Size { get; set; }
    }
}