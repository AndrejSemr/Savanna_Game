using AnimalsBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class create an dictionary for anymals type.
    /// </summary>
    public class TypeKeeper
    {
        /// <summary>
        /// Dictionary save animals type.
        /// </summary>
        public Dictionary<ConsoleKey, Type> typeDictionary = new Dictionary<ConsoleKey, Type>();

        /// <summary>
        /// Class create an dictionary for anymals type.
        /// </summary>
        public TypeKeeper()
        {
            CheckDLLAndAddAnimals();
        }

        /// <summary>
        /// Method check existing .DLL file in folder.
        /// </summary>
        private void CheckDLLAndAddAnimals()
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] Files = directory.GetFiles("*.dll"); 
            
            if (Files.Length > 1)
            {
                foreach (FileInfo file in Files)
                {
                    ClassReader(file.Name);
                }
            }
        }

        /// <summary>
        /// Method loads .DLL file and adds new animals to Dictionary.
        /// </summary>
        /// <param name="filename"> .DLL file name. </param>
        private void ClassReader(string filename)
        {
            Assembly assembly = Assembly.LoadFrom(filename);
            
            foreach (Type type in assembly.GetTypes())
            {
                if ( (type.IsSubclassOf(typeof(Hunters))) || (type.IsSubclassOf(typeof(Herbivores))) )
                {
                    object instanceOfMyType = Activator.CreateInstance(type, 2, 2);
                    AnimalsBase.Animal tmp = (AnimalsBase.Animal)instanceOfMyType;
                    ConsoleKey key = tmp.AnimalConsoleKey;

                    typeDictionary.Add(key, type);
                }
            }
        }

    }
}
