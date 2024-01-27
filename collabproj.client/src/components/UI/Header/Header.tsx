import { Link } from "react-router-dom";
import './Header.css'; 

export default function Header() {
    return (
        <div className="header-container">
            <div className="header-navigation">
                <div className="logo-container">
                    <img src="https://static.thenounproject.com/png/4700132-200.png" alt="WebsiteLogo" />
                </div>
                <div className="title-container">
                    <h1>Our Website</h1>
                </div>
                <nav className="nav-container">
                    <ul>
                        <li><Link to="/">Home</Link></li>
                        <li><Link to="/logIn">LogIn</Link></li>
                        <li><Link to="/profile">Profile</Link></li>
                        <li><Link to="/register">Register</Link></li>
                        <li><Link to="/editProfile">Edit Profile</Link></li>
                    </ul>
                </nav>
            </div>
            <div className="profileIcon" style={{ backgroundColor: '#e3e3e3', borderRadius: '50px' }}></div>
        </div>
    );
}
