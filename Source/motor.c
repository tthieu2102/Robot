/*
 * Date: 29/10/2015
 * Writter: Loc Pham
 * Description: This file contains function implementations concerned with controlling motor
 */

#include "stm32f4xx.h"
#include <stdio.h>
#include "gpio.h"
#include "tm_stm32f4_pwm.h"
#include "motor.h"

void Motor_Init(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        // Preparations
        GPIO_InitTypeDef gpio_init;
        GPIO_StructInit(&gpio_init);
        
        // Enable clock 
        GPIO_EnableClock(p_motor->gpio_port);
        
        // Initialize GPIO
        gpio_init.GPIO_Mode = GPIO_Mode_OUT;
        gpio_init.GPIO_OType = GPIO_OType_PP;
        gpio_init.GPIO_Pin = (p_motor->gpio_direction_pin_1) | (p_motor->gpio_direction_pin_2);
        gpio_init.GPIO_PuPd = GPIO_PuPd_UP;
        gpio_init.GPIO_Speed = GPIO_Speed_50MHz;
        
        GPIO_Init(p_motor->gpio_port, &gpio_init);
        
        // Go into brake state
        TM_PWM_SetChannelPercent(&(p_motor->tim_data), p_motor->pwm_channel, p_motor->speed);
        Motor_Brake(p_motor);
    }
}

void Motor_Brake(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        GPIO_WriteBit(p_motor->gpio_port, p_motor->gpio_direction_pin_1, Bit_RESET);
        GPIO_WriteBit(p_motor->gpio_port, p_motor->gpio_direction_pin_2, Bit_RESET);
    }
}

void Motor_MoveForward(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        GPIO_WriteBit(p_motor->gpio_port, p_motor->gpio_direction_pin_1, Bit_RESET);
        GPIO_WriteBit(p_motor->gpio_port, p_motor->gpio_direction_pin_2, Bit_SET);
    }
}

void Motor_MoveBackward(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        GPIO_WriteBit(p_motor->gpio_port, p_motor->gpio_direction_pin_2, Bit_RESET);
        GPIO_WriteBit(p_motor->gpio_port, p_motor->gpio_direction_pin_1, Bit_SET);
    }
}

void Motor_Move(motor_t* p_motor)
{
    if (p_motor != NULL)
    {
        switch (p_motor->direction)
        {
            case MotorBrake:
                Motor_Brake(p_motor);
                break;
            case MotorBackward:
                Motor_MoveBackward(p_motor);
                break;
            case MotorForward:
                Motor_MoveForward(p_motor);
                break;
            default:
                // Do nothing
                break;
        }
    }
}

motor_direction_e Motor_GetDirection(motor_t* p_motor)
{
    motor_direction_e result = MotorBrake;
    if (p_motor != NULL)
    {
        result = p_motor->direction;
    }
    
    return result;
}

void Motor_SetDirection(motor_t* p_motor, motor_direction_e direction)
{
    if (p_motor != NULL)
    {
        p_motor->direction = direction;
    }
}


//22-11-2015 @Hieu
/*
 * Name: Motor_SetSpeedLevel
 * Module: Motor
 * Parameters:  speedPercent: 0-100%
 * Description: Set motor's speed level
 * Return: void
 */
void Motor_SetSpeed(motor_t* p_motor, float speed)
{
    if ((p_motor != NULL) && (speed >= MOTOR_MIN_SPEED) && (speed <= MOTOR_MAX_SPEED))
    {
        p_motor->speed = speed;
        TM_PWM_SetChannelPercent(&(p_motor->tim_data), p_motor->pwm_channel, p_motor->speed);
    }
}

//24-11-2015 @Hieu
/*
 * Name: Motor_ChangeSpeed
 * Module: Motor
 * Parameters:  increase: > 0 to increase speed, <= 0 to decrease speed
 * Description: Change motor's speed up or down
 * Return: void
 */
void Motor_ChangeSpeed(motor_t* p_motor, uint8_t increase)
{
    if ((p_motor != NULL))
    {
        if (increase > 0)
        {
            p_motor->speed += MOTOR_SPEED_CHANGE_INTERVAL;
        }
        else
        {
            p_motor->speed -= MOTOR_SPEED_CHANGE_INTERVAL;            
        }
        
        TM_PWM_SetChannelPercent(&(p_motor->tim_data), p_motor->pwm_channel, p_motor->speed);
    }
}

/* End file */
