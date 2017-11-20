# Pattern Generator (PattGen)

Pattern Generator (or PattGen for short) is a small, lightweight piece of software created by RedGate Software Ltd. Most basically, it’s a program with a purposeful memory leak.

The program generates patterns by feeding a few random numbers into a generation algorithm and then stores these in byte arrays as to put the generated images in “.NET memory” so the memory profiler can “see” the leaked memory.

## Overview

The program is very simple to operate. On opening the program, a **“Pattern Generator”** window fades in. This window contains a big button, labelled **“Generate…”** and some text explaining that pressing the button will generate 440 images (this is the set number of images that the program generates for each button-press). If a memory profiling tool (such as **ANTS Memory Profiler**) is being using to run the program – you may wish to take a snapshot before pressing the **“Generate…”** button to show that the memory usage is low before generation.

Upon clicking the button, a second window fades in — the **“Image Window”**. This window immediately begins generating patterns and the progress of generation (out of the 440 images) is represented in the bottom right corner of the image window. The slider at the top (labelled **“Timeline”**) remains disabled until generation is finished.

When generation is finished, the user can scroll through the images generated using the slider. Note that the slider can be controlled in a variety of ways, including:

* The mouse
* The `up` and `down` arrow keys
* The `left` and `right` arrow keys
* The `PgUp` and `PgDown` keys
* The `Home` and `End` keys

Images that have been generated are likely to be bias towards the colour blue due to the algorithm, however this shouldn’t really matter unless presenting the program on a projector or screen with poor colour quality (in which case it might be useful to scroll through the images until finding an image which displays clearly). If a memory profiling tool is being used at this point – you may wish to take a snapshot (before closing the image window).

Upon closing the image window, the window will fade out. The memory that was used to store the images should however still be present as the program leaks this memory. If a memory profiling tool is being used at this point – you may wish to take a snapshot now to show that the images are still in memory, even when the image window is closed (hence there is a memory leak!).

Note that if the **“Generate…”** button is pressed again after the first image window has been closed, the program may hang or crash part way through due to an **“Out of Memory”** Exception.

## Solution

Showing how to fix the leak in the program might be useful – a few lines of code in the `VideoWindow_FormClosing` method should do the trick. Add an *else* statement to the `!m_Closeable` *if* statement and in this *else* clause, unhook the `NewImage` event from the `OnNewImage` method:

```cs
else
{
  m_ImageGenerator.NewImage -= OnNewImage;
}
```
