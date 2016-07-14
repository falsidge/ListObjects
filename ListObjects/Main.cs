using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework;
namespace ListObjects
{
    public class ListObjects : Mod
    {
        public override void Entry(params object[] objects)
        {
            Command.RegisterCommand("out_objects", "Outputs a list of objects in game | out_objects", new[] { "" }).CommandFired += listobjects;
        }
        private static void listobjects(object sender, EventArgsCommand e)
        {
            foreach (GameLocation gameLocation in Game1.locations)
            {
                Dictionary<Vector2, StardewValley.Object>.ValueCollection valueColl =
       gameLocation.Objects.Values;
                foreach (StardewValley.Object s in valueColl)
                {
                    if (e.Command.CalledArgs.Length == 0 || s.Name == e.Command.CalledArgs[0])
                        Log.Verbose(s.Name + " : " + gameLocation.Name);
                }
                if (gameLocation.orePanPoint != Point.Zero && (e.Command.CalledArgs.Length == 0 || e.Command.CalledArgs[0] == "orePanPoint"))
                {
                    Log.Verbose("Ore pan point in " + gameLocation.Name);
                }
                if (gameLocation.fishSplashPoint != Point.Zero && (e.Command.CalledArgs.Length == 0 || e.Command.CalledArgs[0] == "fishSplashPoint"))
                {
                    Log.Verbose("Fish splash point in " + gameLocation.Name);
                }
            }
        }
    }
}
