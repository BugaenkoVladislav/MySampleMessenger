import {Typography} from "@mui/material";

const MessageForm = ({ text },{color}) => {
    return (
        <div style={{backgroundColor: color}}>
            <p>{text}</p>
        </div>
    );
};
export default MessageForm