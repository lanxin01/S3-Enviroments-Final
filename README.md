# S3-Enviroments-Final

# Unity Game - Guarding the Fairy Tale Town

1.Description

Guarding Fairy Tale Town Game is a fun shooting game designed for preschoolers. Pre-school children are active and have a low level of cognition of things. At this period, children learn through direct experience or games to achieve the best results. I designed this Unity first-person shooter game inspired by the fairy tale "Guardian Homeland". I hope this game will help children develop brave character and independent problem-solving thinking.

Demo Video

Youtube link:

2.Game design process

![images](https://github.com/lanxin01/S3-image/blob/main/%E6%88%AA%E5%B1%8F2021-06-21%20%E4%B8%8B%E5%8D%885.49.30.png)

Movement:
Provide WSAD movement for the character, the movement speed is 4, the speed is 8 when running, and the speed is 2 when squatting. (There is an unresolved bug here. While pressing W, press A and D, the speed will change to 10, resulting in a disguised acceleration.) FP Character Controller Movement. Then there is also lock the camera up and down to allow the viewing angle It is more in line with "people" & FP Mouse Look (in the later learning video, it is found that Unity has its own character movement footsteps & Standard Assets.) The speed of the sound feedback of the movement is also adjusted according to the speed range of 2-10.

3.Model: 
The movement of the character will be switched according to the value of the speed range 2 to 10 (the movement of the model is also adjusted in detail with respect to the feedback of footsteps to achieve a step-by-step movement, so that the sound and the movement match) There are also changes in the animation &AK47-Animator 1. Firearms will produce sparks, bullets and shells will pop out of animation effects &Assault Rifle. While the firearm animation is running, the corresponding sound is matched to make it more realistic and experience better. The bullet uses collision trigger damage, and the bullet will disappear after 3s &Bullet. (Because it disappears when the collision is not pre-added, it is estimated that the effect of two birds with one stone can be achieved).

4.Terrain: 
Compared to different terrains, different footstep sounds are produced. Each terrain footstep has 4 similar footsteps, making the footstep sounds more realistic and vivid.&Player Footstep Listener&FP Footstep Audio Data.

5.AI: Completed random movement and generation & Go On Patrol.

6.Props: Skybox and map have been added.

Summary
The game development process is basically smooth, and time is mainly spent on the production of the protagonist, but some problems have also been encountered. AI patrols sometimes get stuck, changing to a different floor rendering and then malfunctioning. For weapon aiming, it was originally planned to add a scope, because the efficiency is not high and only naked aiming. In the original script design, the bullet mark effect of bullet hits, switching pistols and throwing grenades was missing. I learned a lot during the development of the game this time, and I hope to make more progress in the future.
