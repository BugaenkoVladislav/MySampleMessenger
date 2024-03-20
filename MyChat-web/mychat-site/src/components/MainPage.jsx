import {Link} from "react-router-dom";
import MessageForm from "./MessageForm.jsx";
import React, { useState, useEffect } from 'react';
import * as signalR from '@microsoft/signalr';
export default function MainPage(){

    const authToken = localStorage.getItem('auth_token');
    const [message, setMessage] = useState('');
    const [connection, setConnection] = useState(
        new signalR.HubConnectionBuilder()
            .configureLogging(signalR.LogLevel.Information)
            .withUrl("http://localhost:5139/chat",{ accessTokenFactory: () => authToken }) // Замените на URL вашего SignalR Hub
            .build()
    );



        // Запускаем соединение
    if (connection.state === signalR.HubConnectionState.Disconnected) {
        // Запускаем соединение
        connection.start().then(() => {
            console.log("Connection started successfully!");
            // Вы можете продолжить выполнение вашей логики после успешного запуска соединения
        }).catch((error) => {
            console.error("Error while starting connection:", error);
        });
    }


    const sendMessage = () => {
        if (connection) {
            connection.invoke("SendToUser", 2, message)
                .then(() => {
                    console.log("Message sent successfully!");
                })
                .catch((error) => {
                    console.error("Error while sending message:", error);
                });
            setMessage('');
        }
    };

    connection.on("SendForUser", (username, message) => {
        console.log(`Message from ${username}: ${message}`);
        setMessage(message);
    });

    return (
        <form>
            <input
                type="text"
                value={message}
                onChange={(e) => setMessage(e.target.value)}
                placeholder="Enter your message..."
            />
            <button type="button" onClick={sendMessage}>Send</button>
        </form>
    );
}