import { memo } from 'react';
import Featured from '../../../commonTypes/Featured';
import './FeaturedItem.css'; 

function FeaturedItem({topic, description} : Featured) {
    return (
        <div className="featured-item">
            <h3>{topic}</h3>
            <p>{description}</p>
        </div>
    );
}

export default memo(FeaturedItem);
