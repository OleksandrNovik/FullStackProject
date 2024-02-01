import { FormEvent, useState } from 'react';
import validatePassword from '../../validators/validatePassword';
import validateEmail from '../../validators/validateEmail';
import './LogIn.css';
import { useNavigate } from 'react-router-dom';

export default function LogIn() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const isEmailValid = validateEmail(email);
    const isPasswordValid = validatePassword(password);

    const navigate = useNavigate();

    const isDisabled = !isEmailValid || !isPasswordValid;

    const onSubmit = (e: FormEvent) =>{
        e.preventDefault();
        console.log(email);
        console.log(password);

        navigate("/");
    }

    return (
        <div className="login-container">
          <h1>Log In</h1>
          <form className="login-form" onSubmit={onSubmit}>
            <label htmlFor="email">Email:</label>
            <input type="text" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Enter your email"/>
            {!isEmailValid && <div className="error">Email should be valid</div>}
    
            <label htmlFor="password">Password:</label>
            <input type="password" id="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Enter your password"/>
            {!isPasswordValid && <div className="error">Password should be at least 8 character in length</div>}
    
            <button type="submit" disabled={isDisabled}>Log In</button>
          </form>
        </div>
      );

}