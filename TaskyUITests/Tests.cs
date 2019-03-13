﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

//Code Reference
/* Automation, E., 2017. Part 4 - Creating and understanding Xamarin.UITest mobile automation project. [Online] 
  Available at: https://www.youtube.com/watch?v=iUAjDdgXrQ4&list=PL6tu16kXT9PrMxnBCfaw-24nVNoY-SZ9U&index=4
 [Accessed 20 02 2019].

 Automation, E., 2017. Part 5 - Record and playback in Xamarin with Xamarin Test Recorder. [Online] 
 Available at: https://www.youtube.com/watch?v=i7YQysK1dlo&list=PL6tu16kXT9PrMxnBCfaw-24nVNoY-SZ9U&index=5
 [Accessed 20 02 2019].
*/

namespace TaskyUITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        // https://nftb.saturdaymp.com/today-i-learned-how-to-create-xamarin-ios-and-android-unit-tests/
        [Test]
        public void SmokeTest()
        {
            Assert.That(true);
        }


        [Test]
        public void EnterTextExample()
        {
            app.Tap(x => x.Marked("Add Task"));
            app.Tap(x => x.Text("Item name"));

            app.Screenshot("Before calling EnterText");
            app.EnterText("The test worked!");
            app.Screenshot("Text entered");
            app.Back();
        }


        // https://github.com/King-of-Spades/AppCenter-Test-Samples/blob/master/Xamarin.UITest/UITestDemo/UITestDemo.UITest
        [Test]
        public void ClearTextExample()
        {
            app.Tap(x => x.Marked("Add Task"));
            app.Tap(x => x.Text("Item name"));

            app.Screenshot("Before calling ClearText");
            app.ClearText();
            app.EnterText("The test worked!");
            app.Screenshot("Text cleared & replaced");
            app.Back();
        }
    }
}

