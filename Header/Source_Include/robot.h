/*
 * Date: 29/10/2015
 * Writter: Loc Pham
 * Description: This file contains function prototypes concerned with controlling robot
 */

 /* NOTE: IN THIS VERSION, WE WILL IGNORE SPEED OF MOTOR DUE TO LACK OF KNOWLEDGE ABOUT CREATING PWM SIGNAL */

#ifndef _ROBOT_H
#define _ROBOT_H

// MACROS
#define ROBOT_INIT_SPEED            90
#define ROBOT_MAX_SPEED             90
#define ROBOT_MIN_SPEED             0
#define ROBOT_SPEED_CHANGE_INTERVAL 10

// ROBOT's MOTOR CONFIGURATIONS
#define MOTOR_PORT GPIOE
// Motor RIGHT
#define MOTOR_RIGHT_OUT_1           GPIO_Pin_2
#define MOTOR_RIGHT_OUT_2           GPIO_Pin_3
#define MOTOR_RIGHT_TIM             TIM2        //
#define MOTOR_RIGHT_TIM_FREQUENCY   50        //
#define MOTOR_RIGHT_PWM_CHANNEL     TM_PWM_Channel_3        //
#define MOTOR_RIGHT_PWM_PINPACK     TM_PWM_PinsPack_1
// Motor LEFT
#define MOTOR_LEFT_OUT_1            GPIO_Pin_4
#define MOTOR_LEFT_OUT_2            GPIO_Pin_5
#define MOTOR_LEFT_TIM              TIM4
#define MOTOR_LEFT_TIM_FREQUENCY    50        //
#define MOTOR_LEFT_PWM_CHANNEL      TM_PWM_Channel_3
#define MOTOR_LEFT_PWM_PINPACK      TM_PWM_PinsPack_1
#define MOTOR_SPEED 255

// ROBOT's USART CONTROLLER CONFIGURATIONS
#define USART_PORT GPIOD
#define USART_TYPE USART2
#define USART_TX GPIO_Pin_5
#define USART_RX GPIO_Pin_6

#define USART_BAUD_RATE 38400u
#define USART_HARDWARE_FLOW_CONTROL USART_HardwareFlowControl_None
#define USART_MODE (USART_Mode_Tx | USART_Mode_Rx)
#define USART_PARITY USART_Parity_No
#define USART_STOP_BITS USART_StopBits_1
#define USART_WORD_LENGTH USART_WordLength_8b

#define SPEED_MAX_VALUE         90
#define SPEED_MEDIUM_VALUE      50
#define SPEED_MIN_VALUE         0
#define SPEED_0_VALUE         0
#define SPEED_25_VALUE        25
#define SPEED_50_VALUE        50
#define SPEED_75_VALUE        75
#define SPEED_100_VALUE       90

// Enum types
typedef enum
{
    RobotBrake          = 0x00,
    RobotForward        = 0x01,
    RobotForwardLeft    = 0x02,
    RobotForwardRight   = 0x03,
    RobotBackward       = 0x04,    
    RobotBackwardLeft   = 0x05,
    RobotBackwardRight  = 0x06,     
    
    RobotRotateLeft     = 0x07,
    RobotRotateRight    = 0x08,
    RobotUnknown        = 0xFF
} robot_direction_e;

typedef enum
{
    RobotSpeedIncrease  = 0x10,
    RobotSpeedDecrease  = 0x11,
    RobotSpeedMax       = 0x12,
    RobotSpeedMedium    = 0x13,
    RobotSpeedMin       = 0x14,    
    RobotSpeed_0        = 0x15,
    RobotSpeed_25       = 0x16,     
    RobotSpeed_50       = 0x17,
    RobotSpeed_75       = 0x18,
    RobotSpeed_100      = 0x19
} robot_speed_command_e;

// Struct types
typedef struct
{
    motor_t motor_left;
    motor_t motor_right;
    usart_t uart_receiver;
    // more to comes
    //22-11-2015 @HIeu
    float speed;
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

//22-11-2015 @Hieu
/*
 * Name: Robot_SetSpeed
 * Module: Motor
 * Parameters:  speedPercent: 0-100%
 * Description: Set robot's speed
 * Return: void
 */
void Robot_SetSpeed(robot_t* p_robot, float speed);

//22-11-2015 @Hieu
/*
 * Name: Robot_ChangeSpeed
 * Module: Motor
 * Parameters:  increase: > 0 to increase speed, <= 0 to decrease speed
 * Description: Change robot's speed up or down
 * Return: void
 */
void Robot_ChangeSpeed(robot_t* p_robot, uint8_t increase);
#endif
/* End file */
