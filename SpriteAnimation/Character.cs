using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SpriteAnimation
{
    class Character
    {
        //sprite
        Texture2D characterTexture;
        //bounding box
        Rectangle characterRectangle; //rectangle in which character will be drawn
        //position
        Vector2 characterPosition;
        //movement variables
        public int MOVEMENT;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        float timer = 0f;//certain amount of time which needs to pass, before flipping to next frame
        float interval = 200f;
        int currentFrame = 0;
        int spriteWidth = 40;//width of each sprite animation
        int spriteHeight = 22;//height of each sprite animation
        int spriteSpeed = 2;

        Vector2 origin;

        KeyboardState currentKBState;
        KeyboardState previousKBState;

        public Vector2 Position {get; set;}
        
        public Vector2 Origin {get; set;}

        public Texture2D Texture { get; set; }

        public Rectangle CharacterRectangle { get; set; }

        //load
        public void Load(ContentManager theContent)
        {

        }
        //update
        public void Update(GameTime theGameTime)
        {
            //handle sprite movement here
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();
            //0 changes depending on up,down,left,right
            characterRectangle = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            if (currentKBState.GetPressedKeys().Length == 0)
            {//resets this if key isn't pressed to first picture in row for that action

                if (currentFrame > 0 && currentFrame < 3)
                {

                    currentFrame = 0;

                }

                if (currentFrame > 4 && currentFrame < 6)
                {

                    currentFrame = 4;

                }

                if (currentFrame > 8 && currentFrame < 9)
                {

                    currentFrame = 8;

                }

                if (currentFrame > 12 && currentFrame < 12)
                {

                    currentFrame = 12;

                }

                if (currentKBState.IsKeyDown(Keys.Right) == true)
                {
                    AnimateRight(theGameTime);
                    if (characterPosition.X < 780)
                    {
                        characterPosition.X += spriteSpeed;
                    }
                }

                if (currentKBState.IsKeyDown(Keys.Left) == true)
                {

                    AnimateLeft(theGameTime);
                    if (characterPosition.X > 20)
                    {

                        characterPosition.X -= spriteSpeed;
                    }

                }

                if (currentKBState.IsKeyDown(Keys.Down) == true)
                {

                    AnimateDown(theGameTime);

                    if (characterPosition.Y < 575)
                    {
                        characterPosition.Y += spriteSpeed;
                    }

                }

                if (currentKBState.IsKeyDown(Keys.Up) == true)
                {
                    AnimateUp(theGameTime);
                    if (characterPosition.Y > 25)
                    {
                        characterPosition.Y -= spriteSpeed;
                    }
                }
                origin = new Vector2(characterRectangle.Width / 2, characterRectangle.Height / 2);

            }


        


        }
        //draw
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(characterTexture, characterPosition, Color.White);
        }
        //constructor. initializes data types
        public void AnimatedSprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            //initialise variables. Can do without this tbh
            this.characterTexture = texture;//this. signifies the global variable
            //it could be this.texture = texture, where 2nd texture is the one parsed into this
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }


        public void AnimateRight(GameTime gameTime)

        {

            if (currentKBState != previousKBState)

            {

                currentFrame = 4;

            }

         

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

         

            if (timer > interval)

            {

                currentFrame++;

                 

                if (currentFrame > 6)

                {

                    currentFrame = 4;

                }

                timer = 0f;

            }

        }
        public void AnimateUp(GameTime gameTime)

        {

            if (currentKBState != previousKBState)

            {

                currentFrame = 1;

            }

 

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

 

            if (timer > interval)

            {

                currentFrame++;

 

                if (currentFrame > 3)

                {

                    currentFrame = 1;

                }

                timer = 0f;

            }

        }
        public void AnimateDown(GameTime gameTime)

        {

            if (currentKBState != previousKBState)

            {

                currentFrame = 7;

            }

 

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

 

            if (timer > interval)

            {

                currentFrame++;

 

                if (currentFrame > 9)

                {

                    currentFrame = 7;

                }

                timer = 0f;

            }

        }
        public void AnimateLeft(GameTime gameTime)

        {

            if (currentKBState != previousKBState)

            {

                currentFrame = 10;

            }

 

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

 

            if (timer > interval)

            {

                currentFrame++;

 

                if (currentFrame > 12)

                {

                    currentFrame = 10;

                }

                timer = 0f;

            }

        }



    }
}
