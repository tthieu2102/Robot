/*
 * Date: 29/10/2015
 * Writer: Loc Pham
 * Description: This file contains function implementations concerned with controlling robot 
 */

#include <stdio.h>
#include "stm32f4xx.h"
#include "gpio.h"
#include "tm_stm32f4_pwm.h"
#include "button.h"
#include "uart.h"
#include "motor.h"
#include "robot.h"


void LeftMotor_Configure(motor_t* p_motor, float speed)
{
    if (p_motor != NULL)
    {
        p_motor->direction = MotorForward;
        p_motor->speed = speed;
        p_motor->gpio_port = MOTOR_PORT;
        p_motor->gpio_direction_pin_1 = MOTOR_LEFT_OUT_1;
        p_motor->gpio_direction_pin_2 = MOTOR_LEFT_OUT_2;
        
        //Configure PWM
        p_motor->pwm_channel = MOTOR_LEFT_PWM_CHANNEL;
        TM_PWM_InitTimer(MOTOR_LEFT_TIM, &(p_motor->tim_data), MOTOR_LEFT_TIM_FREQUENCY);
        TM_PWM_InitChannel(&(p_motor->tim_data), p_motor->pwm_channel, MOTOR_LEFT_PWM_PINPACK);
    }
}

void RightMotor_Configure(motor_t* p_motor, float speed)
{
    if (p_motor != NULL)
    {
        p_motor->direction = MotorForward;
        p_motor->speed = speed;
        p_motor->gpio_port = MOTOR_PORT;
        p_motor->gpio_direction_pin_1 = MOTOR_RIGHT_OUT_1;
        p_motor->gpio_direction_pin_2 = MOTOR_RIGHT_OUT_2;
        
        //Configure PWM
        p_motor->pwm_channel = MOTOR_RIGHT_PWM_CHANNEL;
        TM_PWM_InitTimer(MOTOR_RIGHT_TIM, &(p_motor->tim_data), MOTOR_RIGHT_TIM_FREQUENCY);
        TM_PWM_InitChannel(&(p_motor->tim_data), MOTOR_RIGHT_PWM_CHANNEL, MOTOR_RIGHT_PWM_PINPACK);
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

void Robot_Init(robot_t* p_robot)
{
    p_robot->speed = ROBOT_INIT_SPEED;
    
    RightMotor_Configure(&(p_robot->motor_right), p_robot->speed);
    LeftMotor_Configure(&(p_robot->motor_left), p_robot->speed);
    UARTReceiver_Configure(&(p_robot->uart_receiver));
    
    if (p_robot != NULL)
    {
        Motor_Init(&(p_robot->motor_left));
        Motor_Init(&(p_robot->motor_right));
        USART_MyInit(&(p_robot->uart_receiver));
    }
}

void Robot_Move(robot_t* p_robot, robot_direction_e direction)
{
    if (p_robot != NULL)
    {
        Robot_SetDirection(p_robot, direction);
        
        Motor_Move(&(p_robot->motor_left));
        Motor_Move(&(p_robot->motor_right));
    }
}

robot_direction_e Robot_GetDirection(robot_t* p_robot)
{
    robot_direction_e result = RobotBrake;
    
    if (p_robot != NULL)
    {
        motor_direction_e l_motor_direction = Motor_GetDirection(&(p_robot->motor_left));
        motor_direction_e r_motor_direction = Motor_GetDirection(&(p_robot->motor_right));
        
        if (l_motor_direction == MotorForward)
        {
            switch (r_motor_direction)
            {
                case MotorForward:
                    result = RobotForward;
                    break;
                case MotorBrake:
                    result = RobotForwardRight;
                    break;
                case MotorBackward:                    
                    result = RobotRotateRight;
                    break;
            }
        }
        else if (l_motor_direction == MotorBackward)
        {
            switch (r_motor_direction)
            {
                case MotorForward:
                    result = RobotRotateLeft;
                    break;
                case MotorBrake:
                    result = RobotBackwardRight;
                    break;
                case MotorBackward:                    
                    result = RobotBackward;
                    break;
            }
        }
        else if (l_motor_direction == MotorBrake)
        {
            switch (r_motor_direction)
            {
                case MotorForward:
                    result = RobotForwardLeft;
                    break;
                case MotorBrake:
                    result = RobotBrake;
                    break;
                case MotorBackward:                    
                    result = RobotBackwardLeft;
                    break;
            }
        }
        else 
        {
            // Do nothing
        }
    }
    
    return result;
}

void Robot_SetDirection(robot_t* p_robot, robot_direction_e direction)
{
    if (p_robot != NULL)
    {
        switch (direction)
        {
            case RobotBrake:
                Motor_SetDirection(&(p_robot->motor_left), MotorBrake);
                Motor_SetDirection(&(p_robot->motor_right), MotorBrake);
                break;
            case RobotForward:
                Motor_SetDirection(&(p_robot->motor_left), MotorForward);
                Motor_SetDirection(&(p_robot->motor_right), MotorForward);
                break;
            case RobotBackward:
                Motor_SetDirection(&(p_robot->motor_left), MotorBackward);
                Motor_SetDirection(&(p_robot->motor_right), MotorBackward);                
                break;
            case RobotForwardLeft:
                Motor_SetDirection(&(p_robot->motor_left), MotorBrake);
                Motor_SetDirection(&(p_robot->motor_right), MotorForward);                
                break;
            case RobotForwardRight:
                Motor_SetDirection(&(p_robot->motor_left), MotorForward);
                Motor_SetDirection(&(p_robot->motor_right), MotorBrake);
                break;
            case RobotBackwardLeft:
                Motor_SetDirection(&(p_robot->motor_left), MotorBrake);
                Motor_SetDirection(&(p_robot->motor_right), MotorBackward);                
                break;
            case RobotBackwardRight:
                Motor_SetDirection(&(p_robot->motor_left), MotorBackward);
                Motor_SetDirection(&(p_robot->motor_right), MotorBrake);
                break;
            case RobotUnknown:
                // Do nothing
                break;
            default:
                // Do nothing
                break;
        }
    }
}

//22-11-2015 @Hieu
/*
 * Name: Robot_SetSpeed
 * Module: Motor
 * Parameters:  speedPercent: 0-100%
 * Description: Set robot's speed
 * Return: void
 */
void Robot_SetSpeed(robot_t* p_robot, float speed)
{
    if ((p_robot != NULL) && (speed >= ROBOT_MIN_SPEED) && (speed <= ROBOT_MAX_SPEED))
    {
        p_robot->speed = speed;
        Motor_SetSpeed(&(p_robot->motor_left), p_robot->speed);
        Motor_SetSpeed(&(p_robot->motor_right), p_robot->speed);
    }
}

//22-11-2015 @Hieu
/*
 * Name: Robot_ChangeSpeed
 * Module: Motor
 * Parameters:  increase: > 0 to increase speed, <= 0 to decrease speed
 * Description: Change robot's speed up or down
 * Return: void
 */
void Robot_ChangeSpeed(robot_t* p_robot, uint8_t increase)
{
    if (p_robot != NULL)
    {
        if ((increase > 0) && ((p_robot->speed + ROBOT_SPEED_CHANGE_INTERVAL) <= ROBOT_MAX_SPEED))
        {
            p_robot->speed += ROBOT_SPEED_CHANGE_INTERVAL;
            
            Motor_SetSpeed(&(p_robot->motor_left), p_robot->speed);
            Motor_SetSpeed(&(p_robot->motor_right), p_robot->speed);
            
        }
        else if ((p_robot->speed - ROBOT_SPEED_CHANGE_INTERVAL) >= ROBOT_MIN_SPEED)
        {
            p_robot->speed -= ROBOT_SPEED_CHANGE_INTERVAL;
                        
            Motor_SetSpeed(&(p_robot->motor_left), p_robot->speed);
            Motor_SetSpeed(&(p_robot->motor_right), p_robot->speed);
        }
    }
}
/* End file */
