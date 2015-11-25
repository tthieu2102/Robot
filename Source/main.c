/*
 * Date: 17/10/2015
 * Writer: Loc Pham
 * Description: Main entry
 * Program Description: 
 *      Phrase 1. Make robot move
 *          Press Up, Down, Left, Right to make robot move forward, backward, turn left, turn right
 */
#include <stdio.h>
#include "stm32f4xx.h"
#include "gpio.h"
#include "tm_stm32f4_pwm.h"
#include "stm32f4xx_gpio.h"
#include "string.h"
#include "system.h"
#include "button.h"
#include "uart.h"
#include "motor.h"
#include "robot.h"
#include "keyboard.h"
#include "led.h"
#include "main.h"


int main(void)
{
    // Preparations
    GPIO_InitTypeDef gpio_init;
    keyboard_t keyboard;
    robot_t robot;
    uint16_t command = 0;
    
    memset(&robot, 0, sizeof(robot_t));
    memset(&keyboard, 0, sizeof(keyboard_t));
    
    // System clock initialization
    SysClock_Init();
    
    // Robot initializations
    
    Robot_Init(&robot);
    
    // Keyboard initialization
    Keyboard_Configure(&keyboard);
    
    //-----------------------------------
            // Preparations
        
        GPIO_StructInit(&gpio_init);
        
        // Enable clock 
        GPIO_EnableClock(GPIOD);
        
        // Initialize GPIO
        gpio_init.GPIO_Mode = GPIO_Mode_OUT;
        gpio_init.GPIO_OType = GPIO_OType_PP;
        gpio_init.GPIO_Pin = GPIO_Pin_12;
        gpio_init.GPIO_PuPd = GPIO_PuPd_UP;
        gpio_init.GPIO_Speed = GPIO_Speed_50MHz;
        
        GPIO_Init(GPIOD, &gpio_init);
        GPIOD->ODR = 1 << GPIO_Pin_12;
    //-----------------------------------
    
    for (; ; )
    {
        // Listen for receiving command
        command = USART_MyReceiveData(robot.uart_receiver.usart_type);
        
        // Check command
        if ((command == RobotForward) || (command == RobotForwardLeft) || (command == RobotForwardRight)
            || (command == RobotBackward) || (command == RobotBackwardLeft) || (command == RobotBackwardRight)
            || (command == RobotBrake))
        {
            // Go forward
            Robot_Move(&robot, command);
        }
        else if (command == RobotSpeedIncrease)
        {
            Robot_ChangeSpeed(&robot, 1);
        }
        else if (command == RobotSpeedDecrease)
        {
            Robot_ChangeSpeed(&robot, 0);
        }
        else if (command == RobotSpeedMax)
        {
            // Speed run at SPEED_MAX_VALUE%
            Robot_SetSpeed(&robot, SPEED_MAX_VALUE);
        }
        else if (command == RobotSpeedMedium)
        {
            // Speed run at SPEED_MEDIUM_VALUE%
            Robot_SetSpeed(&robot, SPEED_MEDIUM_VALUE);
        }
        else if (command == RobotSpeedMin)
        {
            // Speed run at SPEED_MIN_VALUE%
            Robot_SetSpeed(&robot, SPEED_MIN_VALUE);
        }
        else if (command == RobotSpeed_0)
        {
            // Speed 0 = brake
            Robot_Move(&robot, RobotBrake);
        }
        else if (command == RobotSpeed_25)
        {
            // Speed 25 = run at 25%
            Robot_SetSpeed(&robot, SPEED_25_VALUE);
        }
        else if (command == RobotSpeed_50)
        {
            // Speed 50 = run at 50%
            Robot_SetSpeed(&robot, SPEED_50_VALUE);
        }
        else if (command == RobotSpeed_75)
        {
            // Speed 75 = run at 75%
            Robot_SetSpeed(&robot, SPEED_75_VALUE);
        }
        else if (command == RobotSpeed_100)
        {
            // Speed 100 = run at 100%
            Robot_SetSpeed(&robot, SPEED_100_VALUE);
        }
        else 
        {
            // Do nothing
        }
    }
}


void OnOffButton_Configure(button_t* p_button)
{
    if (p_button != NULL)
    {
        p_button->mode = ButtonOff;
        p_button->button = BUTTON_USER;
    }
}



void Keyboard_Configure(keyboard_t* p_keyboard)
{
    if (p_keyboard != NULL)
    {
        p_keyboard->up = KEYBOARD_UP;
        p_keyboard->down = KEYBOARD_DOWN;
        p_keyboard->left = KEYBOARD_LEFT;
        p_keyboard->right = KEYBOARD_RIGHT;
        p_keyboard->terminator = KEYBOARD_TERM;
    }
}

/*End file*/
