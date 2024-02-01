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
                        <li><Link to="/edit-profile">Edit Profile</Link></li>
                        <li><Link to="/topic-library/1">Topic Library</Link></li>
                    </ul>
                </nav>
            </div>
            <div className="search-container">
                <input type="search" className="search-input" placeholder="Search here" name="search" id="search-input" />
            </div>
            <div className="profileIcon"></div>
        </div>
    );
}
