import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Footer from '../UI/Footer';
import './Profile.css';

export default function Profile() {
    const [profileImage, setProfileImage] = useState('https://png.pngtree.com/png-vector/20220807/ourmid/pngtree-man-avatar-wearing-gray-suit-png-image_6102786.png'); // Replace with the actual default image URL
    
    const navigate = useNavigate();

    return (
        <div className="profile-container">
            <header className="profile-header">
                <h1>User Name</h1>
                <p>Description holder</p>
            </header>
            <main className="profile-content">
                <img src={profileImage} alt="Profile" className="profile-image" />
                <button className="edit-profile-button" onClick={() => navigate("/edit-profile")}>Edit Profile</button>

                <section className="user-details">
                    <h2>User Details</h2>
                    <p><strong>Email:</strong> user@example.com</p>
                    <p><strong>Location:</strong> City, Country</p>
                    <p><strong>Joined:</strong> January 2022</p>
                </section>

                <section className="bio">
                    <h2>Bio</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                </section>
            </main>
            <Footer />
        </div>
    );

}
