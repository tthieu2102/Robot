/*
 * Date: 29/10/2015
 * Writter: Loc Pham
 * Description: This file contains function prototypes concerned with controlling robot
 */

 /* NOTE: IN THIS VERSION, WE WILL IGNORE SPEED OF MOTOR DUE TO LACK OF KNOWLEDGE ABOUT CREATING PWM SIGNAL */

#ifndef _ROBOT_H
#define _ROBOT_H

// Include header files
#include "stm32f4xx.h"
#include "motor.h"
#include "button.h"
#include "uart.h"

// MACROS

// ROBOT's MOTOR CONFIGURATIONS
// #define ENA ??
// #define ENB ??
#define MOTOR_PORT GPIOB
#define MOTOR_SPEED 255
#define MOTOR_IN1 GPIO_Pin_4
#define MOTOR_IN2 GPIO_Pin_5
#define MOTOR_IN3 GPIO_Pin_6
#define MOTOR_IN4 GPIO_Pin_7

// ROBOT's CONTROLLER CONFIGURATIONS
#define USART_PORT GPIOB
#define USART_TYPE USART3
#define USART_TX GPIO_Pin_10
#define USART_RX GPIO_Pin_11

#define USART_BAUD_RATE 38400u
#define USART_HARDWARE_FLOW_CONTROL USART_HardwareFlowControl_None
#define USART_MODE (USART_Mode_Tx | USART_Mode_Rx)
#define USART_PARITY USART_Parity_No
#define USART_STOP_BITS USART_StopBits_1
#define USART_WORD_LENGTH USART_WordLength_8b

// Enum types
typedef enum
{
    RobotForward,
    RobotBackward,
    RobotLeft, 
    RobotRight,
    RobotBrake,
    RobotUnknown
} robot_direction_e;

// Struct types
typedef struct
{
    motor_t motor_left;
    motor_t motor_right;
    usart_t uart_receiver;
    // more to comes
} robot_t;

// PUBLIC function declarations
/*
 * Name: Robot_Init
 * Module: Motor
 * Parameters:  None
 * Description: Initialize robot (After done execute function, p_robot's values won't be changed)
 * Return: void
 */
void Robot_Init(robot_t* p_robot);

/*
 * Name: Robot_Move
 * Module: Motor
 * Parameters:  None
 * Description: Move robot
 * Return: void
 */
void Robot_Move(robot_t* p_robot, robot_direction_e direction);

/*
 * Name: Robot_GetDirection
 * Module: Motor
 * Parameters:  None
 * Description: Get robot's direction (After done execute function, p_robot's values won't be changed)
 * Return: robot_direction_e
 */
robot_direction_e Robot_GetDirection(robot_t* p_robot);

/*
 * Name: Robot_SetDirection
 * Module: Motor
 * Parameters:  None
 * Description: Set robot's direction
 * Return: void
 */
void Robot_SetDirection(robot_t* p_robot, robot_direction_e direction);



#endif
/* End file */
