import FeaturedItem from '../UI/FeaturedItem';
import { Link } from 'react-router-dom';
import Footer from '../UI/Footer';
import './Home.css'; 

export default function Home() {
    return (
        <div className="home-container">
            <header>
                <h1>My Website</h1>
            </header>
            <section className="welcome-section">
                <h2>Welcome to My Website!</h2>
                <p>
                    Explore, learn, and discover a variety of topics. 
                    Whether you're a beginner or an expert, there's something for everyone.
                </p>
            </section>
            <section className="featured-section">
                <h2>Featured Content</h2>
                <div className="featured-content">
                    <FeaturedItem topic={"Topic 1"} description={"Description of Topic 1."}/>
                    <FeaturedItem topic={"Topic 2"} description={"Description of Topic 2."}/>
                </div>
            </section>
            <section className="cta-section">
                <h2>Ready to Get Started?</h2>
                <p>Join our community and start your learning journey today.</p>
                <Link to="/register"><button className="cta-button">Sign Up Now</button></Link>
            </section>
            <Footer />
        </div>
    );
}
