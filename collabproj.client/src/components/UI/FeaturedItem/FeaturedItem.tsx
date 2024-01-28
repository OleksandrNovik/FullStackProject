import { memo } from 'react';
import './FeaturedItem.css'; 
import Featured from '../../../commontypes/Featured';

function FeaturedItem({topic, description} : Featured) {
    return (
        <div className="featured-item">
            <h3>{topic}</h3>
            <p>{description}</p>
        </div>
    );
}

export default memo(FeaturedItem);
