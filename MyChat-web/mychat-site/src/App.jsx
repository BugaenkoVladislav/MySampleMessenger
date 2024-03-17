import React, { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Welcome from "./components/Welcome.jsx";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import SignUp from "./components/SignUp.jsx";
import MainPage from "./components/MainPage.jsx";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
        <Router>
            <Routes>
                <Route path="/" element={<Welcome/>} />
                <Route path="/signup" element={<SignUp/>} />
                <Route path="/mainpage" element={<MainPage/>} />
            </Routes>
        </Router>
    </>
  )
}

export default App
