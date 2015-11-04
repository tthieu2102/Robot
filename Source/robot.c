/*
 * Date: 29/10/2015
 * Writer: Loc Pham
 * Description: This file contains function implementations concerned with controlling robot 
 */

#include "robot.h"
#include <stdio.h>

void Robot_Init(robot_t* p_robot)
{
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
                    result = RobotRight;
                    break;
                case MotorBackward:                    
                    result = RobotBrake;
                    break;
            }
        }
        else if (l_motor_direction == MotorBackward)
        {
            switch (r_motor_direction)
            {
                case MotorForward:
                    result = RobotBrake;
                    break;
                case MotorBrake:
                    result = RobotUnknown;
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
                    result = RobotLeft;
                    break;
                case MotorBrake:
                    result = RobotBrake;
                    break;
                case MotorBackward:                    
                    result = RobotUnknown;
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
            case RobotLeft:
                Motor_SetDirection(&(p_robot->motor_left), MotorBrake);
                Motor_SetDirection(&(p_robot->motor_right), MotorForward);                
                break;
            case RobotRight:
                Motor_SetDirection(&(p_robot->motor_left), MotorForward);
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

/* End file */
