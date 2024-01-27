import React from 'react';
import './FeaturedItem.css'; 

interface Featured {
    topic: string,
    description: string,
}

const FeaturedItem = React.memo(function FeaturedItem({topic, description} : Featured) {
    return (
        <div className="featured-item">
            <h3>{topic}</h3>
            <p>{description}</p>
        </div>
    );
})

export default FeaturedItem;
