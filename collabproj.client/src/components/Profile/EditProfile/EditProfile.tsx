import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import validateName from '../../../validators/validateName';
import Footer from '../../UI/Footer';
import './EditProfile.css';

export default function EditProfile() {
    const [firstName, setFirstName] = useState('John');
    const [lastName, setLastName] = useState('Doe');
    const [profileImage, setProfileImage] = useState('https://png.pngtree.com/png-vector/20220807/ourmid/pngtree-man-avatar-wearing-gray-suit-png-image_6102786.png'); // Replace with the actual default image URL

    const isFirstNameValid = validateName(firstName);
    const isLastNameValid = validateName(lastName);

    const navigate = useNavigate();

    const isDisabled = !isFirstNameValid || !isLastNameValid;

    const handleSaveChanges = () => {
        console.log('Changes saved:', { firstName, lastName });
        navigate("/profile");
    };

    const handleDiscardChanges = () => {
        console.log('Changes discarded');
    };

    const handleProfileImageChange = () => {
        console.log('Profile image changed');
    };

    const handleDeleteProfileImage = () => {
        console.log('Profile image deleted');
    };

    return (
        <div className="edit-profile-container">
            <header>
                <h1>Edit Profile</h1>
            </header>

            <div className="edit-profile-content">
                <div className="profile-image-section">
                    <img src={profileImage} alt="Profile" />
                    <div className="image-actions">
                        <button onClick={handleProfileImageChange}>Change</button>
                        <button onClick={handleDeleteProfileImage}>Delete</button>
                    </div>
                </div>

                <form className="edit-profile-form">
                    <label htmlFor="firstName">First Name:</label>
                    <input
                        type="text"
                        id="firstName"
                        name="firstName"
                        value={firstName}
                        onChange={e => setFirstName(e.target.value)}
                        placeholder="Enter your first name"
                    />
                    {!isFirstNameValid && <div className="error">First Name is required</div>}

                    <label htmlFor="lastName">Last Name:</label>
                    <input
                        type="text"
                        id="lastName"
                        name="lastName"
                        value={lastName}
                        onChange={e => setLastName(e.target.value)}
                        placeholder="Enter your last name"
                    />
                    {!isLastNameValid && <div className="error">Last Name is required</div>}

                    <div className="form-actions">
                        <button type="button" disabled={isDisabled} onClick={handleSaveChanges}>
                            Save Changes
                        </button>
                        <button type="button" onClick={handleDiscardChanges}>
                            Discard Changes
                        </button>
                    </div>
                </form>
            </div>

            <Footer />
        </div>
    );
}
