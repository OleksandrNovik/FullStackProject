import { FormEvent, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import validatePassword from '../../validators/validatePassword';
import validateEmail from '../../validators/validateEmail';
import validateName from '../../validators/validateName';
import './Register.css';

export default function Register() {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const isFirstNameValid = validateName(firstName);
    const isLastNameValid = validateName(lastName);
    const isEmailValid = validateEmail(email);
    const isPasswordValid = validatePassword(password);
    const isConfirmPasswordValid = password === confirmPassword;

    const navigate = useNavigate();

    const isDisabled = !isFirstNameValid || !isLastNameValid || !isEmailValid || !isPasswordValid || !isConfirmPasswordValid;

    const onSubmit = (e: FormEvent) =>{
        e.preventDefault();
        console.log(email);
        console.log(password);

        navigate("/");
    }

    return (
        <div className="register-container">
          <h1>Sign Up</h1>
          <form className="register-form" onSubmit={onSubmit}>
            <label htmlFor="first-name">* First Name:</label>
            <input type="text" id="first-name" name="first-name" value={firstName} onChange={(e) => setFirstName(e.target.value)} placeholder="Enter your first name"/>
            {!isFirstNameValid && <div className="error">First Name is required</div>}

            <label htmlFor="last-name">* Last Name:</label>
            <input type="text" id="last-name" name="last-name" value={lastName} onChange={(e) => setLastName(e.target.value)} placeholder="Enter your last name"/>
            {!isLastNameValid && <div className="error">Last Name is required</div>}

            <label htmlFor="email">* Email:</label>
            <input type="text" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Enter your email"/>
            {!isEmailValid && <div className="error">Email should be valid</div>}
    
            <label htmlFor="password">* Password:</label>
            <input type="password" id="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Enter your password"/>
            {!isPasswordValid && <div className="error">Password should be at least 8 character in length</div>}

            <label htmlFor="confirm-password">* Confirm Password:</label>
            <input type="password" id="confirm-password" name="confirm-password" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} placeholder="Enter your password again to confirm"/>
            {!isConfirmPasswordValid && <div className="error">Confirm password should be same as password</div>}
    
            <button type="submit" disabled={isDisabled}>Sign Up</button>
          </form>
        </div>
      );

}