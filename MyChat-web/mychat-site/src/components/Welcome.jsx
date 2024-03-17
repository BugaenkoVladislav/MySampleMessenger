import React, {useState} from "react";
import {
    Button,
    FormControl,
    IconButton,
    InputAdornment,
    InputLabel,
    OutlinedInput,
    TextField,
    Typography
} from "@mui/material";
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import {Link, Navigate, useNavigate} from "react-router-dom";
import axios from 'axios';
export default function Welcome(){
    const [login,setLogin] = useState('')
    const [password,setPassword] = useState('')
    const [showPassword, setShowPassword] = React.useState(false);
    const [token, setToken] = useState(''); // State to store the token

    const navigate = useNavigate();
    const loginChange = (event) => {
        setLogin(event.target.value);
    }
    const handleClickShowPassword = () => setShowPassword((show) => !show);

    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };
    const passwordChange = (event) =>{
        setPassword(event.target.value)
    }
    async function sendData(){
        const url = 'http://localhost:5221/api/Authorization/SignIn';
        const data = {
            Email: login,
            Password: password
        };
        try {
            const response = await axios.post(url, data);
            setToken(response.data.data);
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
            navigate("/mainpage");
        }
        catch (error) {
            console.log(error.message)
        }
    }

    return(
        <>
            <div className={"column"}>
                <Typography variant="h4" color={'black'} component="h4">
                    You are welcome
                </Typography>
                <TextField
                    value={login}
                    onChange={loginChange}
                    sx={{m: 1, width: '50ch'}}
                    label={"Email"}
                    variant={"outlined"}
                />
                <FormControl sx={{m: 1, width: '50ch'}} variant="outlined">
                    <InputLabel
                        htmlFor="outlined-adornment-password">Password</InputLabel>
                    <OutlinedInput
                        id="outlined-adornment-password"
                        type={showPassword ? 'text' : 'password'}
                        endAdornment={
                            <InputAdornment position="end">
                                <IconButton
                                    aria-label="toggle password visibility"
                                    onClick={handleClickShowPassword}
                                    onMouseDown={handleMouseDownPassword}
                                    edge="end">
                                    {showPassword ? <VisibilityOff/> : <Visibility/>}
                                </IconButton>
                            </InputAdornment>
                        }
                        label="Password"
                        value={password}
                        onChange={passwordChange}
                    />
                </FormControl>
                <Button sx={{m: 2, width: '55ch', height:'5ch'}} variant="contained" onClick={sendData} >Enter</Button>
                <Link to="/signup">Dont have account?</Link>

            </div>
        </>
    );
}