/*
 * Date: 17/10/2015
 * Writer: Loc Pham
 * Decription: Implement function prototypes
 */
 
// Include header files
#include "uart.h"
#include "gpio.h"

uint8_t USART_IsSentComplete(USART_TypeDef* UARTx)
{
    uint8_t result = 0u;
    if (UARTx != 0)
    {
        result = (UARTx->SR & TC_BIT) >> TC_SHIFT_LEFT;
    }
    
    return result;
}

uint8_t USART_IsReceivedComplete(USART_TypeDef* UARTx)
{
    uint8_t result = 0u;
    if (UARTx != 0)
    {
        result = (UARTx->SR & RXNE_BIT) >> RXNE_SHIFT_LEFT;
    }
    
    return result;
}

void USART_MySendData(USART_TypeDef* USARTx, uint16_t data)
{
    if (USARTx != 0)
    {
        USART_SendData(USARTx, data);
    
        while (!(USART_IsSentComplete(USARTx) == 1))
        {
            // Do nothing
        }
    }
}

uint16_t USART_MyReceiveData(USART_TypeDef* USARTx)
{
    uint16_t data = 0u;
    if (USARTx != 0)
    {
        while (!(USART_IsReceivedComplete(USARTx) == 1))
        {
            // Do nothing
        }
    
        data = USART_ReceiveData(USARTx);
    }
    return data;
}

void USART_MySendDataStr(USART_TypeDef* USARTx, uint16_t* data_str, uint16_t str_length)
{
    uint16_t counter = 0u;
    if (USARTx != 0 && data_str != 0)
    {
        for (; counter < str_length; counter++)
        {
            USART_MySendData(USARTx, data_str[counter]);
        }
    }
}

void USART_MyReceiveDataStr(USART_TypeDef* USARTx, uint16_t* data_str, uint16_t str_length)
{
    uint16_t counter = 0u;
    if (USARTx != 0 && data_str != 0 && str_length != 0)
    {
        memset(data_str, 0, str_length);
        for (; counter < str_length; counter++)
        {
            data_str[counter] = USART_MyReceiveData(USARTx);
        }
    }
}

void USART_MySendCharStr(USART_TypeDef* USARTx, char* data_str, uint16_t str_length)
{
    if (USARTx != 0 && data_str != 0 && str_length > 0)
    {
        uint16_t new_data_str[MAX_DATA_STR];
        str_length = MAX_DATA_STR;
        string_to_uint16_array(data_str, new_data_str, &str_length);
        
        USART_MySendDataStr(USARTx, new_data_str, str_length);
    }
}

void USART_MyInit(usart_t* usart)
{
    // Preprations
    GPIO_InitTypeDef gpio_init;
    
    // Enable peripheral clock for USART3
    USART_EnableClock(usart);
    
    // With USART3, we have to use usart->tx as TX and usart->rx as RX in usart->port
    GPIO_EnableClock(usart->port);
    
    // Connect the pin to the desired peripherals' Alternate Function (AF)
    USART_ConnectPinsToAF(usart);
    
    // Configure the desired pin in alternate function
    gpio_init.GPIO_Mode = GPIO_Mode_AF;
    gpio_init.GPIO_OType = GPIO_OType_PP;
    gpio_init.GPIO_Pin = usart->rx_pin | usart->tx_pin;
    gpio_init.GPIO_PuPd = GPIO_PuPd_UP;
    gpio_init.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(usart->port, &gpio_init);
    
    // Program the Baud Rate, Word Length , Stop Bit, Parity, Hardware flow 
    // control and Mode(Receiver/Transmitter)
    USART_Init(usart->usart_type, &(usart->config));
    
    // Enable USART3
    USART_Cmd(usart->usart_type, ENABLE);
}

void USART_EnableClock(usart_t* usart)
{
    if (usart != NULL)
    {
        if (usart->usart_type == USART1)
        {
            RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1, ENABLE);
        }
        else if (usart->usart_type == USART2)
        {
            RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2, ENABLE);
        }
        else if (usart->usart_type == USART3)
        {
            RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3, ENABLE);
        }
        else if (usart->usart_type == UART4)
        {
            RCC_APB1PeriphClockCmd(RCC_APB1Periph_UART4, ENABLE);
        }
        else if (usart->usart_type == UART5)
        {
            RCC_APB1PeriphClockCmd(RCC_APB1Periph_UART5, ENABLE);
        }
        else if (usart->usart_type == USART6)
        {
            RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART6, ENABLE);
        }
        else
        {
            // Do nothing
        }
    }
}

void USART_ConnectPinsToAF(usart_t* usart)
{
    if (usart != NULL)
    {
        GPIO_TypeDef* port = usart->port;
        uint8_t rx_pin_source = GPIO_ToGPIOPinSource(usart->rx_pin);
        uint8_t tx_pin_source = GPIO_ToGPIOPinSource(usart->tx_pin);
        
        if (usart->usart_type == USART1)
        {
            GPIO_PinAFConfig(port, rx_pin_source, GPIO_AF_USART1);
            GPIO_PinAFConfig(port, tx_pin_source, GPIO_AF_USART1);
        }
        else if (usart->usart_type == USART2)
        {
            GPIO_PinAFConfig(port, rx_pin_source, GPIO_AF_USART2);
            GPIO_PinAFConfig(port, tx_pin_source, GPIO_AF_USART2);
        }
        else if (usart->usart_type == USART3)
        {
            GPIO_PinAFConfig(port, rx_pin_source, GPIO_AF_USART3);
            GPIO_PinAFConfig(port, tx_pin_source, GPIO_AF_USART3);
        }
        else if (usart->usart_type == UART4)
        {
            GPIO_PinAFConfig(port, rx_pin_source, GPIO_AF_UART4);
            GPIO_PinAFConfig(port, tx_pin_source, GPIO_AF_UART4);
        }
        else if (usart->usart_type == UART5)
        {
            GPIO_PinAFConfig(port, rx_pin_source, GPIO_AF_UART5);
            GPIO_PinAFConfig(port, tx_pin_source, GPIO_AF_UART5);
        }
        else if (usart->usart_type == USART6)
        {
            GPIO_PinAFConfig(port, rx_pin_source, GPIO_AF_USART6);
            GPIO_PinAFConfig(port, tx_pin_source, GPIO_AF_USART6);
        }
        else
        {
            // Do nothing
        }
    }
}

/* End file */
