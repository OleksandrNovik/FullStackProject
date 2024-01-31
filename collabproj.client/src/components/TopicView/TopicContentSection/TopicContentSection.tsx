import TopicElementInfo from "../../../commonTypes/TopicElementInfo";
import TopicContentItem from "./TopicContentItem/TopicContentItem";
import TopicSectionSelector from "./TopicContentItem/TopicSectionSelector";

interface TopicContentProps {
    items: TopicElementInfo[];
    isEditable: boolean;
}
// Topic content section needed to group up all elements (headers, text, code, etc.) in correct order
function TopicContentSection({items, isEditable}:TopicContentProps) {
    //TODO: items is temporary, topic id should be provided
    return <div>
        { items.map(item => <TopicContentItem key={item.id} item={item} isEditable={isEditable} />) }
        {/* Shows select list to chose what content piece we can add next */}
        { isEditable && <TopicSectionSelector /> }
    </div>
}

export default TopicContentSection;