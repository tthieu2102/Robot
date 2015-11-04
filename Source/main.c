/*
 * Date: 17/10/2015
 * Writer: Loc Pham
 * Description: Main entry
 * Program Description: 
 *      Phrase 1. Make robot move
 *          Press Up, Down, Left, Right to make robot move forward, backward, turn left, turn right
 */

#include "main.h"
#include "string.h"
#include "system.h"
#include "led.h"
#include "stm32f4xx_gpio.h"
#include "gpio.h"

int main(void)
{
    // Preparations
    keyboard_t keyboard;
    robot_t robot;
    uint16_t data = 0;
    
    memset(&robot, 0, sizeof(robot_t));
    memset(&keyboard, 0, sizeof(keyboard_t));
    
    // System clock initialization
    SysClock_Init();
    
    // Robot initializations
    RightMotor_Configure(&(robot.motor_right));
    LeftMotor_Configure(&(robot.motor_left));
    UARTReceiver_Configure(&(robot.uart_receiver));
    Robot_Init(&robot);
    
    // Keyboard initialization
    Keyboard_Configure(&keyboard);
    
    //-----------------------------------
            // Preparations
        GPIO_InitTypeDef gpio_init;
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
        // Listen for receiving data
        data = USART_MyReceiveData(robot.uart_receiver.usart_type);
        
        // Check data
        if (data == keyboard.up)
        {
            // Go forward
            Robot_Move(&robot, RobotForward);
        }
        else if (data == keyboard.down)
        {
            // Go backward
            Robot_Move(&robot, RobotBackward);
        }
        else if (data == keyboard.left)
        {
            // Go left
            Robot_Move(&robot, RobotLeft);
        }
        else if (data == keyboard.right)
        {
            // Go right
            Robot_Move(&robot, RobotRight);
        }
        else if (data == keyboard.terminator)
        {
            // Brake
            Robot_Move(&robot, RobotBrake);
        }
        else 
        {
            // Do nothing
        }
    }
}

void LeftMotor_Configure(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        p_motor->direction = MotorForward;
        p_motor->speed = MOTOR_SPEED;
        p_motor->gpio_port = MOTOR_PORT;
        p_motor->gpio_direction_pin_1 = MOTOR_IN1;
        p_motor->gpio_direction_pin_2 = MOTOR_IN2;
    }
}

void RightMotor_Configure(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        p_motor->direction = MotorForward;
        p_motor->speed = MOTOR_SPEED;
        p_motor->gpio_port = MOTOR_PORT;
        p_motor->gpio_direction_pin_1 = MOTOR_IN3;
        p_motor->gpio_direction_pin_2 = MOTOR_IN4;
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

void UARTReceiver_Configure(usart_t* p_controller)
{
    if (p_controller != NULL)
    {
        p_controller->usart_type = USART_TYPE;
        p_controller->port = USART_PORT;
        p_controller->rx_pin = USART_RX;
        p_controller->tx_pin = USART_TX;
        
        (p_controller->config).USART_BaudRate = USART_BAUD_RATE;
        (p_controller->config).USART_HardwareFlowControl = USART_HARDWARE_FLOW_CONTROL;
        (p_controller->config).USART_Mode = USART_MODE;
        (p_controller->config).USART_Parity = USART_PARITY;
        (p_controller->config).USART_StopBits = USART_STOP_BITS;
        (p_controller->config).USART_WordLength = USART_WORD_LENGTH;
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
