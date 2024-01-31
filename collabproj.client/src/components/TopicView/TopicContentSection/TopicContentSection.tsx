import TopicElementInfo from "../../../commonTypes/TopicElementInfo";
import TopicContentItem from "./TopicContentItem/TopicContentItem";
import TopicSectionSelector from "./TopicContentItem/TopicSectionSelector";

interface TopicContentProps {
    items: TopicElementInfo[];
    isEditable: boolean;
}

function TopicContentSection({items, isEditable}:TopicContentProps) {
    //TODO: items is temporary, topic id should be provided
    return <div>
        { items.map(item => <TopicContentItem key={item.id} item={item} isEditable={isEditable} />) }
        { isEditable && <TopicSectionSelector /> }
    </div>
}

export default TopicContentSection;